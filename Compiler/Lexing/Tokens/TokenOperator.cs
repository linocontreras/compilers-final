namespace Compiler.Lexing.Tokens
{
    using System;

    public enum Operators { And, LT, Add, Prod }
    public class TokenOperator : Symbol
    {
        public Operators Operator { get; private set; }

        public TokenOperator(Operators @operator) : base(SymbolType.TokenOperator)
        {
            this.Operator = @operator;
        }

        public override string ToString()
        {
            return $"[{Enum.GetName(typeof(SymbolType), this.Type)}] {this.Operator}";
        }
    }
}