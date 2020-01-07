using System.Collections.Generic;
using System;
namespace Lox{
    public class Scanner{
        private readonly string _source;
        private List<Token> _tokens = new List<Token>();
        private int _start = 0;                               
        private int _current = 0;                             
        private int _line = 1;  
        private static readonly Dictionary<string, TokenType> _keywords = new Dictionary<string, TokenType>(){
            {"and", TokenType.AND},
            {"class", TokenType.CLASS},
            {"else", TokenType.ELSE},
            {"false", TokenType.FALSE},
            {"for", TokenType.FOR},
            {"fun", TokenType.FUN},
            {"if", TokenType.IF},
            {"nil", TokenType.NIL},
            {"or", TokenType.OR},
            {"print", TokenType.PRINT},
            {"return", TokenType.RETURN},
            {"super", TokenType.SUPER},
            {"this", TokenType.THIS},
            {"true", TokenType.TRUE},
            {"var", TokenType.VAR},
            {"while", TokenType.WHILE}
        } ;  
        public Scanner(string source)
        {
            this._source = source;
            
        }
        
        public List<Token> ScanTokens(){
            while(!this.IsAtEnd()){
                this._start = this._current;
                this.ScanToken();
            }
            this._tokens.Add(new Token(TokenType.EOF, string.Empty, null, this._line));
            return this._tokens;
        }

        private bool IsAtEnd() => this._current >= this._source.Length;
        private void ScanToken(){
            char c = this.Advance();
            switch (c) {                                 
                case '(': this.AddToken(TokenType.LEFT_PAREN); break;     
                case ')': this.AddToken(TokenType.RIGHT_PAREN); break;    
                case '{': this.AddToken(TokenType.LEFT_BRACE); break;     
                case '}': this.AddToken(TokenType.RIGHT_BRACE); break;    
                case ',': this.AddToken(TokenType.COMMA); break;          
                case '.': this.AddToken(TokenType.DOT); break;            
                case '-': this.AddToken(TokenType.MINUS); break;          
                case '+': this.AddToken(TokenType.PLUS); break;           
                case ';': this.AddToken(TokenType.SEMICOLON); break;      
                case '*': this.AddToken(TokenType.STAR); break;
                case '!': this.AddToken(this.Match('=') ? TokenType.BANG_EQUAL : TokenType.BANG); break;      
                case '=': this.AddToken(this.Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL); break;    
                case '<': this.AddToken(this.Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS); break;      
                case '>': this.AddToken(this.Match('=') ? TokenType.GREATER_EQUAL : TokenType.GREATER); break;
                case '/':                                                       
                    if (this.Match('/')) {                                             
                    // A comment goes until the end of the line.                
                        while (this.Peek() != '\n' && !this.IsAtEnd()) this.Advance();             
                    } else { this.AddToken(TokenType.SLASH); }                                                             
                    break; 
                case ' ':                                    
                case '\r':                                   
                case '\t':                                   
                    // Ignore whitespace.                      
                    break;
                case '\n':                                   
                    this._line++;                                    
                    break;    
                case '"':
                    this.String();
                    break;
                default:   
                    if(this.IsDigit(c)){
                        this.Number();
                    }else if(this.IsAlpha(c)){
                        this.Identifier();
                    }
                    else{
                        Console.Error.WriteLine("[line " + this._line + "] Error" + string.Empty + ": " + "Unexpected character.");    
                    }                           
                    break;
            } 
        }
        private void Identifier(){
            while(this.IsAlphaNumeric(this.Peek())) this.Advance();
            string text = this._source.Substring(this._start, this._current - this._start );
            TokenType type =  TokenType.IDENTIFIER;
            if(_keywords.ContainsKey(text)){
                type = _keywords[text];
            }
            AddToken(type);
        }
        private bool IsAlpha(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c == '_');
        private bool IsAlphaNumeric(char c) => this.IsAlpha(c) || this.IsDigit(c);
        private void String(){
            while(this.Peek() !='"' & !this.IsAtEnd()){
                if(this.Peek() == '\n')this._line++;
                this.Advance();
            }
            if(this.IsAtEnd()){
                Console.Error.WriteLine("[line " + this._line + "] Error" + string.Empty + ": " + "Unterminated string.");   
                return;
            }
            this.Advance();
            string value = _source.Substring(this._start + 1, (this._current - this._start));
            this.AddToken(TokenType.STRING, value);
        }
        private bool IsDigit(char c) => c >= '0' && c <= '9';
        private void Number(){
            while(this.IsDigit(this.Peek())) this.Advance();
            if(this.Peek() == '.' && this.IsDigit(this.Peek())){
                this.Advance();
                while(this.IsDigit(this.Peek())) this.Advance();
            }
            this.AddToken(TokenType.NUMBER, Convert.ToDouble(this._source.Substring(this._start , (this._current - this._start))));
        }
        private char PeekNext(){
            if (this._current + 1 >= this._source.Length) return '\0';
            return this._source[this._current + 1];   
        }
        private char Advance() {                               
            this._current++;                                           
            return this._source[this._current - 1];                   
        }
        private void AddToken(TokenType type) {                
            this.AddToken(type, null);                                
        }                                                      

        private void AddToken(TokenType type, object literal) {
            string text = this._source.Substring(this._start, this._current - this._start);      
            this._tokens.Add(new Token(type, text, literal, this._line));    
        } 
        private bool Match(char expected) {                 
            if (this.IsAtEnd()) return false;                         
            if (this._source[this._current] != expected) return false;
            this._current++;                                           
            return true;                                         
        }
        private char Peek() {           
            if (this.IsAtEnd()) return '\0';   
            return this._source[this._current];
        }    
    }
}