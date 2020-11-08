namespace Lox
{
    public class Literal : Expr
    {
        private readonly object _value;
        public Literal(object value)
        {
            _value = value;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitLiteralExpr(this);
        }
    }
}
