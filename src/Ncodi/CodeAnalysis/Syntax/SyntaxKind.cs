﻿namespace Ncodi.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //Tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        StringToken,
        PlusToken,
        MinusToken,
        HatToken,
        TildeToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        ModuloToken,
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
        ColonToken,

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
        DoKeyword,
        FunctionKeyword,
        ContinueKeyword,
        BreakKeyword,

        //Expressions
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression,
        UnaryExpression,
        NameExpression,
        AssignmentExpression,
        CallExpression,

        //Nodes
        CompilationUnit,
        GlobalStatmenet,
        FunctionDeclaration,
        ElseClause,
        TypeClause,
        Parameter,

        //Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
        CommaToken,
        DoWhileStatement,
        BreakStatement,
        ContinueStatement,
        ReturnKeyword,
        ReturnStatement,
        StarStarToken,
        DoubleToken,
    }
}
