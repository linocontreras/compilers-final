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
                if (this.stack.Peek() == this.lexer.PeekToken().Type) {
                    this.lexer.GetNextToken();
                    this.stack.Pop();
                } else if (this.actions.TryGetValue((this.stack.Peek(), this.lexer.PeekToken().Type), out ICollection<SymbolType> symbols)) {
                    foreach (SymbolType symbol in symbols) {
                        this.stack.Push(symbol);
                    }
                } else {
                    throw new Exception($"Syntax error: Unexpected {this.lexer.PeekToken()} at line {this.lexer.CurrentLine} col {this.lexer.CurrentCol}");
                }
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
