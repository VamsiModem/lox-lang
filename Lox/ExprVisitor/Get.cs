namespace Lox
{
    public class Get : Expr
    {
        private readonly Expr _object;
        private readonly Token _name;

        public Get(Expr @object, Token Name)
        {
            _object = @object;
            _name = Name;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitGetExpr(this);
        }
    }
}
