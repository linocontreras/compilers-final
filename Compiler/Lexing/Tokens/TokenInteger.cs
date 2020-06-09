namespace Compiler.Lexing.Tokens
{

    public class TokenInteger : Symbol
    {
        public int Value { get; private set; }

        public TokenInteger(int value) : base(SymbolType.Integer)
        {
            this.Value = value;
        }
    }
}