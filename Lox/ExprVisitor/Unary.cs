namespace Lox
{
    public class Unary : Expr
    {
        private readonly Token _operator;
        private readonly Expr _right;

        public Unary(Token @operator, Expr right)
        {
            _operator = @operator;
            _right = right;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitUnaryExpr(this);
        }
    }
}
