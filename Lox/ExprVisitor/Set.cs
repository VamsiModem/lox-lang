namespace Lox
{
    public class Set : Expr
    {
        private readonly Expr _object;
        private readonly Token _name;
        private readonly Expr _value;

        public Set(Expr @object, Token name, Expr value)
        {
            _object = @object;
            _name = name;
            _value = value;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitSetExpr(this);
        }
    }
}
