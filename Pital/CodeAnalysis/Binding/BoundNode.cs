﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Pital.CodeAnalysis.Binding
{
    internal abstract class BoundNode
    {
        public abstract BoundNodeKind Kind {get;}

        public IEnumerable<BoundNode> GetChildren()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                if (typeof(BoundNode).IsAssignableFrom(prop.PropertyType))
                {
                    var child = (BoundNode)prop.GetValue(this);
                    yield return child;
                }
                else if (typeof(IEnumerator<BoundNode>).IsAssignableFrom(prop.PropertyType))
                {
                    var children = (IEnumerable<BoundNode>)prop.GetValue(this);
                    foreach (var child in children)
                        yield return child;

                }
            }
        }

        public IEnumerable<(string Name,object Value)> GetProperties()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                if (prop.Name == nameof(Kind) || prop.Name==nameof(BoundBinaryExpression.Op))
                    continue;
                if (typeof(BoundNode).IsAssignableFrom(prop.PropertyType) || typeof(IEnumerator<BoundNode>).IsAssignableFrom(prop.PropertyType))
                    continue;
                var value = prop.GetValue(this);
                if (value != null) ;
                yield return (prop.Name, value);
            }
        }

        public void WriteTo(TextWriter writer)
        {
            TreePrint(writer, this);
        }

        private static void TreePrint(TextWriter writer, BoundNode node, string indent = "", bool isLast = true)
        {
            var isToConsole = writer == Console.Out;
            var marker = isLast ? "└──" : "├──";

            if (isToConsole)
                Console.ForegroundColor = ConsoleColor.DarkGray;

            writer.Write(indent);
            writer.Write(marker);

            if(isToConsole)
                Console.ForegroundColor = GetColor(node);
            var text = GetText(node);
            writer.Write(text);

            var isFirstProperty = true;

            foreach(var p in node.GetProperties())
            {
                if (isFirstProperty)
                    isFirstProperty = false;
                else
                {
                    if(isToConsole)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    writer.Write(",");
                }

                writer.Write(" ");

                if (isToConsole)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                writer.Write(p.Name);

                if (isToConsole)
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                writer.Write(" = ");

                if (isToConsole)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                writer.Write(p.Value);
            }
            

            if (isToConsole)
                Console.ResetColor();

            writer.WriteLine();

            indent += isLast ? "   " : "│  ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
                TreePrint(writer, child, indent, child == lastChild);
        }

        private static void WriteNode(TextWriter writer, BoundNode node)
        {

        }

        private static string GetText(BoundNode node)
        {
            if (node is BoundBinaryExpression b)
                return b.Op.Kind.ToString() + "Expression";

            if (node is BoundUnaryExpression u)
                return u.Op.Kind.ToString() + "Expression";

            return node.Kind.ToString();
        }

        private static ConsoleColor GetColor(BoundNode node)
        {
            if (node is BoundExpression)
                return ConsoleColor.Blue;
            if (node is BoundStatement)
                return ConsoleColor.Cyan;
            return ConsoleColor.Yellow;
        }

        public override string ToString()
        {
            using (var writer = new StringWriter())
            {
                WriteTo(writer);
                return writer.ToString();
            }
        }



    }
}
