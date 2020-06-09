namespace Compiler.Lexing.Tokens
{

    public class TokenIdentifier : Symbol
    {
        public string Value { get; private set; }

        public TokenIdentifier(string value) : base(SymbolType.Identifier)
        {
            this.Value = value;
        }
    }
}