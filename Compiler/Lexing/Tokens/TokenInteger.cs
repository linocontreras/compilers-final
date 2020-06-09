namespace Compiler.Lexing.Tokens
{
    using System;

    public class TokenInteger : Symbol
    {
        public int Value { get; private set; }

        public TokenInteger(int value) : base(SymbolType.TokenInteger)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"[{Enum.GetName(typeof(SymbolType), this.Type)}] {this.Value}";
        }
    }
}