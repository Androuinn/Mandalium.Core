using System.Linq.Expressions;

namespace Mandalium.Core.Persisence.Specifications;

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

    #region paging
    public GenericSpecification(int pageIndex, int pageCount) : base()
    {
        ApplyPaging((pageIndex - 1 * pageCount), pageCount);
    }

    public GenericSpecification(int pageIndex, int pageCount, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        ApplyPaging((pageIndex - 1 * pageCount), pageCount);
    }

    public GenericSpecification(int pageIndex, int pageCount, Expression<Func<T, object>> includeExpression) : base()
    {
        if (includeExpression != null)
            AddInclude(includeExpression);
        ApplyPaging((pageIndex - 1 * pageCount), pageCount);
    }

    public GenericSpecification(int pageIndex, int pageCount, Expression<Func<T, object>> includeExpression, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        if (includeExpression != null)
            AddInclude(includeExpression);
        ApplyPaging((pageIndex - 1 * pageCount), pageCount);
    }

    public GenericSpecification(int pageIndex, int pageCount, List<Expression<Func<T, object>>> includeExpressionList, Expression<Func<T, bool>> criteria) : base(criteria)
    {
        for (int i = 0; i < includeExpressionList.Count; i++)
        {
            if (includeExpressionList[i] != null)
                AddInclude(includeExpressionList[i]);
        }
        ApplyPaging((pageIndex - 1 * pageCount), pageCount);
    }

    #endregion

}

