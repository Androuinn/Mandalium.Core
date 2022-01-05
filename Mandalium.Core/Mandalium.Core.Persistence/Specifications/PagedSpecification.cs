using Mandalium.Core.Persistence.Specifications;
using System.Linq.Expressions;

namespace Mandalium.Core.Persistence.Specifications
{
    public class PagedSpecification<T> : BaseSpecification<T> where T : class
    {
        public PagedSpecification(int pageIndex, int itemCount) : base()
        {
            ApplyPaging((pageIndex - 1) * itemCount, itemCount, pageIndex);
        }

        public PagedSpecification(int pageIndex, int itemCount, Expression<Func<T, bool>> criteria) : base(criteria)
        {
            ApplyPaging((pageIndex - 1) * itemCount, itemCount, pageIndex);
        }

        public PagedSpecification(int pageIndex, int itemCount, Expression<Func<T, object>> includeExpression) : base()
        {
            if (includeExpression != null)
                AddInclude(includeExpression);
            ApplyPaging((pageIndex - 1) * itemCount, itemCount, pageIndex);
        }

        public PagedSpecification(int pageIndex, int itemCount, Expression<Func<T, object>> includeExpression, Expression<Func<T, bool>> criteria) : base(criteria)
        {
            if (includeExpression != null)
                AddInclude(includeExpression);
            ApplyPaging((pageIndex - 1) * itemCount, itemCount, pageIndex);
        }

        public PagedSpecification(int pageIndex, int itemCount, List<Expression<Func<T, object>>> includeExpressionList, Expression<Func<T, bool>> criteria) : base(criteria)
        {
            for (int i = 0; i < includeExpressionList.Count; i++)
            {
                if (includeExpressionList[i] != null)
                    AddInclude(includeExpressionList[i]);
            }
            ApplyPaging((pageIndex - 1) * itemCount, itemCount, pageIndex);
        }
    }
}
