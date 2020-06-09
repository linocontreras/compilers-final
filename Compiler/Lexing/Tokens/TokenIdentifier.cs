namespace Compiler.Lexing.Tokens
{
    using System;

    public class TokenIdentifier : Symbol
    {
        public string Value { get; private set; }

        public TokenIdentifier(string value) : base(SymbolType.TokenId)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"[{Enum.GetName(typeof(SymbolType), this.Type)}] {this.Value}";
        }
    }
}