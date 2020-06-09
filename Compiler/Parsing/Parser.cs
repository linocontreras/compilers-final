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
        private Dictionary<int, ICollection<SymbolType>> productionSymbols = new Dictionary<int, ICollection<SymbolType>>();

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            this.SetUpProductions();
        }

        private void SetUpProductionSymbols()
        {
            this.productionSymbols[1] = new SymbolType[] { SymbolType.DeclarationStar, SymbolType.StatementStar };
            this.productionSymbols[2] = new SymbolType[] { SymbolType.Declaration, SymbolType.DeclarationStar };
            this.productionSymbols[3] = new SymbolType[] { };
            this.productionSymbols[4] = new SymbolType[] { SymbolType.Type, SymbolType.TokenId };
            this.productionSymbols[5] = new SymbolType[] { SymbolType.Statement, SymbolType.StatementStar };
            this.productionSymbols[6] = new SymbolType[] { };
            this.productionSymbols[7] = new SymbolType[] { SymbolType.Assigment };
            this.productionSymbols[8] = new SymbolType[] { SymbolType.Print };
            this.productionSymbols[9] = new SymbolType[] { SymbolType.Condition };
            this.productionSymbols[10] = new SymbolType[] { SymbolType.TokenInt };
            this.productionSymbols[11] = new SymbolType[] { SymbolType.TokenBool };
            this.productionSymbols[12] = new SymbolType[] { SymbolType.TokenId, SymbolType.TokenEquals, SymbolType.Expression };
            this.productionSymbols[13] = new SymbolType[] { SymbolType.Print, SymbolType.Expression };
            this.productionSymbols[14] = new SymbolType[] { SymbolType.TokenIf, SymbolType.Expression, SymbolType.TokenThen, SymbolType.StatementStar, SymbolType.TokenEnd };
            this.productionSymbols[15] = new SymbolType[] { SymbolType.SimpleExpression, SymbolType.ExpressionPrime };
            this.productionSymbols[16] = new SymbolType[] { SymbolType.TokenOperator, SymbolType.SimpleExpression, SymbolType.ExpressionPrime };
            this.productionSymbols[17] = new SymbolType[] { };
            this.productionSymbols[18] = new SymbolType[] { SymbolType.TokenId };
            this.productionSymbols[19] = new SymbolType[] { SymbolType.TokenInteger };
            this.productionSymbols[20] = new SymbolType[] { SymbolType.TokenBoolean };
            this.productionSymbols[21] = new SymbolType[] { SymbolType.TokenLParen, SymbolType.Expression, SymbolType.TokenRParen };
            this.productionSymbols[22] = new SymbolType[] { SymbolType.TokenMinus, SymbolType.SimpleExpression };
        }

        private void SetUpProductions()
        {
            this.SetUpProductionSymbols();
            this.actions[(SymbolType.Program, SymbolType.TokenId)] = this.productionSymbols[1];
        }

        public void Parse()
        {
            while (this.lexer.PeekToken().Type != SymbolType.TokenEOF)
            {
                if (this.stack.Peek() == this.lexer.PeekToken().Type)
                {
                    this.stack.Pop();
                    this.lexer.GetNextToken();
                }
                else if (this.actions.TryGetValue((this.stack.Peek(), this.lexer.PeekToken().Type), out ICollection<SymbolType> symbols))
                {
                    this.stack.Pop();
                    foreach (SymbolType symbol in symbols)
                    {
                        this.stack.Push(symbol);
                    }
                }
                else
                {
                    throw new Exception($"Syntax error: Unexpected {this.lexer.PeekToken()} at line {this.lexer.CurrentLine} col {this.lexer.CurrentCol}");
                }
            }

            if (this.stack.Count == 0)
            {
                Console.WriteLine("Compiled successfully!");
            }
            else
            {
                throw new Exception("Syntax error: Unexpected end of file.");
            }
        }
    }
}
