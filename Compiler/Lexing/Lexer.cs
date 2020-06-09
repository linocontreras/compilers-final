namespace Compiler.Lexing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Tokens;

    public class Lexer
    {
        private TextReader textReader;

        private Dictionary<string, Symbol> keywords = new Dictionary<string, Symbol>();
        private Dictionary<char, Symbol> oneChars = new Dictionary<char, Symbol>();

        public int CurrentLine { get; private set; } = 1;
        public int CurrentCol { get; private set; } = 1;
        private int peek;
        private Symbol peekToken;

        public Lexer(TextReader textReader)
        {
            this.textReader = textReader;
            this.peek = this.textReader.Peek();

            this.SetUpOneChars();
            this.SetUpKeywords();
        }

        public void SetUpOneChars()
        {
            this.oneChars.Add('=', new Token(SymbolType.TokenEquals));
            this.oneChars.Add('&', new TokenOperator(Operators.And));
            this.oneChars.Add('+', new TokenOperator(Operators.Add));
            this.oneChars.Add('*', new TokenOperator(Operators.Prod));
            this.oneChars.Add('<', new TokenOperator(Operators.LT));
            this.oneChars.Add('-', new Token(SymbolType.TokenMinus));
        }

        public void SetUpKeywords()
        {
            this.keywords.Add("int", new Token(SymbolType.TokenInt));
            this.keywords.Add("bool", new Token(SymbolType.TokenBool));
            this.keywords.Add("print", new Token(SymbolType.TokenPrint));
            this.keywords.Add("if", new Token(SymbolType.TokenIf));
            this.keywords.Add("then", new Token(SymbolType.TokenThen));
            this.keywords.Add("end", new Token(SymbolType.TokenEnd));
        }

        public Symbol PeekToken()
        {
            if (peekToken == null)
            {
                this.peekToken = this.GetNextToken();
            }

            return this.peekToken;
        }

        private int Read()
        {
            this.CurrentCol++;
            int res = this.textReader.Read();
            this.peek = this.textReader.Peek();
            return res;
        }

        private void ConsumeSpace()
        {
            while (true)
            {
                switch (this.peek)
                {
                    case ' ':
                    case '\t':
                    case '\r':
                        this.Read();
                        break;
                    case '\n':
                        this.CurrentLine++;
                        this.CurrentCol = 0;
                        this.Read();
                        break;
                    default:
                        return;
                }
            }
        }

        public Symbol GetNextToken()
        {
            if (this.peekToken != null)
            {
                Symbol result = this.peekToken;
                this.peekToken = null;
                return result;
            }

            this.ConsumeSpace();

            if (this.peek == -1)
            {
                return new Token(SymbolType.TokenEOF);
            }

            this.oneChars.TryGetValue((char)this.peek, out Symbol oneChar);

            if (oneChar is Symbol)
            {
                this.Read();
                return oneChar;
            }

            if (this.peek == '#')
            {
                this.Read();

                if (this.peek != 't' && this.peek != 'f')
                {
                    throw new Exception($"({this.CurrentLine}, {this.CurrentCol}) unexpected: " + (char)this.Read());
                }

                return new TokenBoolean(this.Read() == 't');
            }

            if (char.IsLetter((char)this.peek))
            {
                StringBuilder sb = new StringBuilder();

                do
                {
                    sb.Append((char)this.Read());
                } while (char.IsLetter((char)this.peek));

                this.keywords.TryGetValue(sb.ToString(), out Symbol keyword);
                return keyword ?? new TokenIdentifier(sb.ToString());
            }

            if (char.IsDigit((char)this.peek))
            {
                int integer = 0;
                do
                {
                    try
                    {
                        checked
                        {
                            integer *= 10;
                            integer += int.Parse($"{(char)this.Read()}");
                        }
                    }
                    catch (ArithmeticException)
                    {
                        throw new Exception($"({this.CurrentLine}, {this.CurrentCol}) Integer exceeds maximum value of {int.MaxValue}");
                    }

                } while (char.IsDigit((char)this.peek));

                return new TokenInteger(integer);

            }

            throw new Exception($"({this.CurrentLine}, {this.CurrentCol}) unexpected: " + (int)this.Read());
        }
    }
}
