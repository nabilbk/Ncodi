﻿namespace Pital.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //Tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        HatToken,
        TildeToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        ClosedParenthesisToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        AmpersandToken,
        PipeToken,
        EqualsEqualsToken,
        BangEqualsToken,
        BangToken,
        EqualsToken,
        LessOrEqualsToken,
        GreaterToken,
        GreaterOrEqualsToken,
        LessToken,
        OpenBraceToken,
        ClosedBraceToken,
        IdentifierToken,

        //Keywords
        TrueKeyword,
        FalseKeyword,
        ConstKeyword,
        VarKeyword,
        IfKeyword,
        ForKeyword,
        WhileKeyword,
        ElseKeyword,
        ToKeyword,

        //Expressions
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression,
        UnaryExpression,
        NameExpression,
        AssignmentExpression,

        //Nodes
        CompilationUnit,
        ElseClause,

        //Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
    }
}