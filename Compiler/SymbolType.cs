namespace Compiler {
    public enum SymbolType {
        // Tokens
        TokenId,
        TokenInt,
        TokenBool,
        TokenEquals,
        TokenPrint,
        TokenIf,
        TokenThen,
        TokenEnd,
        TokenOperator,
        TokenInteger,
        TokenBoolean,
        TokenLParen,
        TokenRParen,
        TokenMinus,
        TokenEOF,
        // Productions
        Program,
        DeclarationStar,
        Declaration,
        StatementStar,
        Statement,
        Type,
        Asignment,
        Print,
        Condition,
        Expression,
        ExpressionPrime,
        SimpleExpression,
    }
}