namespace Compiler.Lexing.Tokens
{

    public class TokenBoolean : Symbol
    {
        public bool Value { get; private set; }

        public TokenBoolean(bool value) : base(SymbolType.TokenBoolean)
        {
            this.Value = value;
        }
    }
}