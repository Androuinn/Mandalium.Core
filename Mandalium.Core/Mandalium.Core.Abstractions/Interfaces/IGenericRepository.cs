using Mandalium.Core.Generic.Collections;

namespace Mandalium.Core.Abstractions.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get<Type>(Type id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<PagedCollection<T>> GetAllPaged(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task Delete<Type>(Type id, CancellationToken cancellationToken = default);
        Task Update(T entity, CancellationToken cancellationToken = default);
        Task Save(T entity, CancellationToken cancellationToken = default);

        Task Detach(T entity, CancellationToken cancellationToken = default);
    }
}
