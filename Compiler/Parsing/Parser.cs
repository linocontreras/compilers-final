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
        private Dictionary<int, IList<SymbolType>> productionSymbols = new Dictionary<int, IList<SymbolType>>();

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            this.stack.Push(SymbolType.TokenEOF);
            this.stack.Push(SymbolType.Program);
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
            this.productionSymbols[13] = new SymbolType[] { SymbolType.TokenPrint, SymbolType.Expression };
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
            this.actions[(SymbolType.Program, SymbolType.TokenInt)] = this.productionSymbols[1];
            this.actions[(SymbolType.Program, SymbolType.TokenBoolean)] = this.productionSymbols[1];
            this.actions[(SymbolType.Program, SymbolType.TokenPrint)] = this.productionSymbols[1];
            this.actions[(SymbolType.Program, SymbolType.TokenIf)] = this.productionSymbols[1];
            this.actions[(SymbolType.Program, SymbolType.TokenEOF)] = this.productionSymbols[1];

            this.actions[(SymbolType.DeclarationStar, SymbolType.TokenId)] = this.productionSymbols[3];
            this.actions[(SymbolType.DeclarationStar, SymbolType.TokenPrint)] = this.productionSymbols[3];
            this.actions[(SymbolType.DeclarationStar, SymbolType.TokenIf)] = this.productionSymbols[3];
            this.actions[(SymbolType.DeclarationStar, SymbolType.TokenEOF)] = this.productionSymbols[3];
            this.actions[(SymbolType.DeclarationStar, SymbolType.TokenInt)] = this.productionSymbols[2];
            this.actions[(SymbolType.DeclarationStar, SymbolType.TokenBool)] = this.productionSymbols[2];

            this.actions[(SymbolType.Declaration, SymbolType.TokenInt)] = this.productionSymbols[4];
            this.actions[(SymbolType.Declaration, SymbolType.TokenBool)] = this.productionSymbols[4];

            this.actions[(SymbolType.StatementStar, SymbolType.TokenId)] = this.productionSymbols[5];
            this.actions[(SymbolType.StatementStar, SymbolType.TokenPrint)] = this.productionSymbols[5];
            this.actions[(SymbolType.StatementStar, SymbolType.TokenIf)] = this.productionSymbols[5];
            this.actions[(SymbolType.StatementStar, SymbolType.TokenEnd)] = this.productionSymbols[6];
            this.actions[(SymbolType.StatementStar, SymbolType.TokenEOF)] = this.productionSymbols[6];

            this.actions[(SymbolType.Statement, SymbolType.TokenId)] = this.productionSymbols[7];
            this.actions[(SymbolType.Statement, SymbolType.TokenPrint)] = this.productionSymbols[8];
            this.actions[(SymbolType.Statement, SymbolType.TokenIf)] = this.productionSymbols[9];

            this.actions[(SymbolType.Type, SymbolType.TokenInt)] = this.productionSymbols[10];
            this.actions[(SymbolType.Type, SymbolType.TokenBool)] = this.productionSymbols[11];

            this.actions[(SymbolType.Assigment, SymbolType.TokenId)] = this.productionSymbols[12];

            this.actions[(SymbolType.Print, SymbolType.TokenPrint)] = this.productionSymbols[13];

            this.actions[(SymbolType.Condition, SymbolType.TokenIf)] = this.productionSymbols[14];

            this.actions[(SymbolType.Expression, SymbolType.TokenId)] = this.productionSymbols[15];
            this.actions[(SymbolType.Expression, SymbolType.TokenInteger)] = this.productionSymbols[15];
            this.actions[(SymbolType.Expression, SymbolType.TokenBoolean)] = this.productionSymbols[15];
            this.actions[(SymbolType.Expression, SymbolType.TokenLParen)] = this.productionSymbols[15];
            this.actions[(SymbolType.Expression, SymbolType.TokenMinus)] = this.productionSymbols[15];

            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenId)] = this.productionSymbols[17];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenPrint)] = this.productionSymbols[17];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenIf)] = this.productionSymbols[17];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenThen)] = this.productionSymbols[17];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenEnd)] = this.productionSymbols[17];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenOperator)] = this.productionSymbols[16];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenRParen)] = this.productionSymbols[17];
            this.actions[(SymbolType.ExpressionPrime, SymbolType.TokenEOF)] = this.productionSymbols[17];

            this.actions[(SymbolType.SimpleExpression, SymbolType.TokenId)] = this.productionSymbols[18];
            this.actions[(SymbolType.SimpleExpression, SymbolType.TokenInteger)] = this.productionSymbols[19];
            this.actions[(SymbolType.SimpleExpression, SymbolType.TokenBoolean)] = this.productionSymbols[20];
            this.actions[(SymbolType.SimpleExpression, SymbolType.TokenLParen)] = this.productionSymbols[21];
            this.actions[(SymbolType.SimpleExpression, SymbolType.TokenMinus)] = this.productionSymbols[22];
        }

        private void PrintStack() {
            Console.Write("stack: { ");
            foreach (var item in this.stack) {
                Console.Write($"{item}, ");
            }
            Console.WriteLine($"}} next: {this.lexer.PeekToken()}");
        }

        public void Parse()
        {
            while (this.stack.Count > 0)
            {
                // Uncomment for stack printing
                // this.lexer.PeekToken();
                // this.PrintStack();

                if (this.stack.Peek() == this.lexer.PeekToken().Type)
                {
                    this.stack.Pop();
                    this.lexer.GetNextToken();
                }
                else if (this.actions.TryGetValue((this.stack.Peek(), this.lexer.PeekToken().Type), out ICollection<SymbolType> symbols))
                {
                    this.stack.Pop();

                    Stack<SymbolType> toAdd = new Stack<SymbolType>();

                    foreach (SymbolType symbol in symbols)
                    {
                        toAdd.Push(symbol);
                    }

                    foreach (SymbolType symbol in toAdd) {
                        this.stack.Push(symbol);
                    }
                }
                else
                {
                    throw new Exception($"Syntax error: Unexpected {this.lexer.PeekToken()} near line {this.lexer.CurrentLine} col {this.lexer.CurrentCol}");
                }
            }

            Console.WriteLine("Compiled successfully!");
        }
    }
}
