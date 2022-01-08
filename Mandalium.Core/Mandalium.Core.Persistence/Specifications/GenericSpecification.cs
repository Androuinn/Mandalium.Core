using System.Linq.Expressions;

namespace Mandalium.Core.Persistence.Specifications;

public class GenericSpecification<T> : BaseSpecification<T> where T : class
{
    public GenericSpecification() : base() { }
    public GenericSpecification(Expression<Func<T, bool>> criteria) : base(criteria) { }
    public GenericSpecification(Expression<Func<T, object>> includeExpression) : base()
    {
        if (includeExpression != null)
            AddInclude(includeExpression);
    }

    public GenericSpecification(List<Expression<Func<T, object>>> includeExpressionList) : base()
    {
        for (int i = 0; i < includeExpressionList.Count; i++)
        {
            if (includeExpressionList[i] != null)
                AddInclude(includeExpressionList[i]);
        }
    }

    public GenericSpecification(Expression<Func<T, object>> includeExpression, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        AddInclude(includeExpression);
    }

    public GenericSpecification(List<Expression<Func<T, object>>> includeExpressionList, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        for (int i = 0; i < includeExpressionList.Count; i++)
        {
            if (includeExpressionList[i] != null)
                AddInclude(includeExpressionList[i]);
        }
    }
    

}

