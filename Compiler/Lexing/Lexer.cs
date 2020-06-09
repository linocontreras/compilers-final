namespace Compiler.Lexing
{
    using System.Collections.Generic;
    using System.IO;
    using Tokens;

    class Lexer
    {
        private TextReader textReader;

        private Dictionary<string, Symbol> keywords = new Dictionary<string, Symbol>();

        private Dictionary<char, Symbol> oneChars = new Dictionary<char, Symbol>();

        public Lexer(TextReader textReader)
        {
            this.textReader = textReader;
            this.SetUpOneChars();
            this.SetUpKeywords();
        }

        public void SetUpOneChars()
        {
            this.oneChars.Add('=', new Token(SymbolType.Equals));
            this.oneChars.Add('&', new TokenOperator(Operators.And));
            this.oneChars.Add('+', new TokenOperator(Operators.Add));
            this.oneChars.Add('*', new TokenOperator(Operators.Prod));
        }

        public void SetUpKeywords()
        {
            this.keywords.Add("int", new Token(SymbolType.Int));
            this.keywords.Add("bool", new Token(SymbolType.Bool));
            this.keywords.Add("print", new Token(SymbolType.Print));
            this.keywords.Add("if", new Token(SymbolType.If));
            this.keywords.Add("then", new Token(SymbolType.Then));
            this.keywords.Add("end", new Token(SymbolType.End));
        }
    }
}
