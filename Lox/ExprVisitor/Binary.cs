namespace Lox
{
    public class Binary : Expr{
        private readonly Expr _left;
        private readonly Token _operator;
        private readonly Expr _right;

        public Binary(Expr left, Token @operator, Expr right)
        {
            _left = left;
            _operator = @operator;
            _right = right;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitBinaryExpr(this);
        }
    }
}
