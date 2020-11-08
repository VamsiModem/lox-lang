namespace Lox
{
    public class This : Expr
    {
        private readonly Token _token;

        public This(Token token)
        {
            _token = token;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitThisExpr(this);
        }
    }
}
