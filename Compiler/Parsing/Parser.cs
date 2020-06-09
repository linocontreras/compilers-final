namespace Compiler.Parsing {
    using System;
    using System.Collections.Generic;
    using Lexing;

    class Parser {
        private Lexer lexer;

        private Dictionary<string, Symbol> keywords = new Dictionary<string, Symbol>();

        private Dictionary<char, Symbol> oneChars = new Dictionary<char, Symbol>();

        public Parser(Lexer lexer) {
            this.lexer = lexer;
        }

        public void Parse() {
            while (this.lexer.PeekToken().Type != SymbolType.EOF) 
            {
                Console.WriteLine(this.lexer.GetNextToken());
            }
        }
    }
}
