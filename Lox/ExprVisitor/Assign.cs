namespace Lox
{
    public class Assign : Expr
    {
        private readonly Token _token;
        private readonly Expr _expression;

        public Assign(Token token, Expr expression)
        {
            _token = token;
            _expression = expression;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitAssignExpr(this);
        }
    }
}
