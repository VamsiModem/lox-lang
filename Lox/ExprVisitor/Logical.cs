namespace Lox
{
    public class Logical : Expr
    {
        private readonly Expr _left;
        private readonly Token _operator;
        private readonly Expr _right;
        public Logical(Expr left, Token @operator, Expr right)
        {
            _left = left;
            _operator = @operator;
            _right = right;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitLogicalExpr(this);
        }
    }
}
