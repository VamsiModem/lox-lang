namespace Lox
{
    public class Variable : Expr
    {
        private readonly Token _name;

        public Variable(Token name)
        {
            _name = name;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitVariableExpr(this);
        }
    }
}
