using Mandalium.Core.Abstractions.Interfaces;

namespace Mandalium.Core.Persistence.Helper
{
    public static class SpecificationHelper
    {
        public static ISpecification<T> GetWithoutPaging<T>(this ISpecification<T> specification) where T : class
        {
            specification.DisablePaging();
            return specification;
        }
    }
}
