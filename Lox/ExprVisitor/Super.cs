namespace Lox
{
    public class Super : Expr
    {
        private readonly Token _keyword;
        private readonly Token _method;

        public Super(Token keyword, Token method)
        {
            _keyword = keyword;
            _method = method;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitSuperExpr(this);
        }
    }
}
