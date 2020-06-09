namespace Compiler.Lexing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Tokens;

    class Lexer
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
            this.SetUpOneChars();
            this.SetUpKeywords();
        }

        public void SetUpOneChars()
        {
            this.oneChars.Add('=', new Token(SymbolType.Equals));
            this.oneChars.Add('&', new TokenOperator(Operators.And));
            this.oneChars.Add('+', new TokenOperator(Operators.Add));
            this.oneChars.Add('*', new TokenOperator(Operators.Prod));
            this.oneChars.Add('-', new Token(SymbolType.Minus));
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
                return new Token(SymbolType.EOF);
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
                    sb.Append(char.ToLower((char)this.Read()));
                } while (char.IsLetterOrDigit((char)this.peek));

                this.keywords.TryGetValue(sb.ToString(), out Symbol keyword);
                return keyword ?? new TokenIdentifier(sb.ToString());
            }

            if (char.IsDigit((char)this.peek))
            {
                int integer = 0;
                do
                {
                    integer *= 10;
                    integer += int.Parse($"{(char)this.Read()}");
                } while (char.IsDigit((char)this.peek));
                        
                    
                
            }

            throw new Exception($"({this.CurrentLine}, {this.CurrentCol}) unexpected: " + (char)this.Read());
        }
    }
}
