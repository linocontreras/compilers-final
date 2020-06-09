namespace Compiler.Lexing {
    using System.IO;

    class Lexer {
        private TextReader textReader;

        public Lexer(TextReader textReader)
        {
            this.textReader = textReader;
        }
    }
}
