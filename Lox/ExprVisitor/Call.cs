using System.Collections.Generic;

namespace Lox
{
    public class Call : Expr
    {
        private readonly Expr _calle;
        private readonly Token _paren;
        private readonly List<Expr> _arguments;

        public Call(Expr calle, Token paren, List<Expr> arguments)
        {
            _calle = calle;
            _paren = paren;
            _arguments = arguments;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitCallExpr(this);
        }
    }
}
