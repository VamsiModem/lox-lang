using System.Text;
using System;

namespace Lox{
    public class Token{
        public TokenType Type{ get;} 
        public string Lexeme{ get;} 
        public object Literal{ get;} 
        public int Line{ get;} 
        public Token(TokenType type, string lexeme, object literal, int line)
        {
            this.Type = type;
            this.Lexeme = lexeme;
            this.Line = line;
            this.Literal = literal;
        }

        public override string ToString() {    
            const string WHITESPACE = " ";                                  
            return new StringBuilder(Enum.GetName(typeof(TokenType), this.Type))
                        .Append(WHITESPACE)
                        .Append(this.Lexeme)
                        .Append(WHITESPACE)
                        .Append(this.Literal)
                        .ToString();                   
        } 
    }
    
}