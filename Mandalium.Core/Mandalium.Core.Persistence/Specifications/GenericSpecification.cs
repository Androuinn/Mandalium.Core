using System.Linq.Expressions;

namespace Mandalium.Core.Persisence.Specifications;

public class GenericSpecification<T> : BaseSpecification<T> where T : class
{
    public GenericSpecification() : base() { }
    public GenericSpecification(Expression<Func<T, bool>> criteria) : base(criteria) { }
    public GenericSpecification(Expression<Func<T, object>> includeExpression) : base()
    {
        AddInclude(includeExpression);
    }

    public GenericSpecification(List<Expression<Func<T, object>>> includeExpressionList) : base()
    {
        foreach (var exp in includeExpressionList)
        {
            AddInclude(exp);
        }
    }

    public GenericSpecification(Expression<Func<T, object>> includeExpression, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        AddInclude(includeExpression);
    }

    public GenericSpecification(List<Expression<Func<T, object>>> includeExpressionList, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        foreach (var exp in includeExpressionList)
        {
            AddInclude(exp);
        }
    }
}

