namespace Compiler.Lexing.Tokens
{
    using System;

    public class TokenBoolean : Symbol
    {
        public bool Value { get; private set; }

        public TokenBoolean(bool value) : base(SymbolType.TokenBoolean)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"[{Enum.GetName(typeof(SymbolType), this.Type)}] {this.Value}";
        }
    }
}