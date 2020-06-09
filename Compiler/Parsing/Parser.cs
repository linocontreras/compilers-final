namespace Compiler.Parsing
{
    using System;
    using System.Collections.Generic;
    using Lexing;

    public class Parser
    {
        private Lexer lexer;

        private Stack<SymbolType> stack = new Stack<SymbolType>();
        private Dictionary<(SymbolType, SymbolType), ICollection<SymbolType>> actions = new Dictionary<(SymbolType, SymbolType), ICollection<SymbolType>>();

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            this.SetUpProductions();
        }

        private void SetUpProductions()
        {
            this.actions[(SymbolType.Program, SymbolType.TokenId)] = new SymbolType[] { SymbolType.DeclarationStar, SymbolType.StatementStar };
        }

        public void Parse()
        {
            while (this.lexer.PeekToken().Type != SymbolType.TokenEOF)
            {
                Console.WriteLine(this.lexer.GetNextToken());
            }

            if (this.stack.Count == 0)
            {
                Console.WriteLine("Compiled successfully!");
            }
            else
            {
                throw new Exception("Unexpected end of file.");
            }
        }
    }
}
