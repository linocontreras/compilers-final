namespace Compiler.Parsing {
    using System;
    using Lexing;

    class Parser {
        private Lexer lexer;

        public Parser(Lexer lexer) {
            this.lexer = lexer;
        }

        public void Parse() {
            throw new Exception("Not implemented!");
        }
    }
}
