namespace Compiler.Lexing.Tokens
{

    public enum Operators { And, LT, Add, Prod }
    public class TokenOperator : Symbol
    {
        public Operators Operator { get; private set; }

        public TokenOperator(Operators @operator) : base(SymbolType.TokenOperator)
        {
            this.Operator = @operator;
        }
    }
}