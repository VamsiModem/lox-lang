namespace Lox
{
    public class Grouping : Expr
    {
        private readonly Expr _expression;
        public Grouping(Expr expression)
        {
            _expression = expression;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitGroupingExpr(this);
        }
    }
}
