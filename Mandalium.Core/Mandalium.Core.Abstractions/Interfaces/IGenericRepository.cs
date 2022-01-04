using Mandalium.Core.Generic.Collections;

namespace Mandalium.Core.Abstractions.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get<Type>(Type id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(ISpecification<T> specification);
        Task<PagedCollection<T>> GetAllPaged(ISpecification<T> specification);
        Task Delete<Type>(Type id);
        Task Update(T entity);
        Task Save(T entity);
    }
}
