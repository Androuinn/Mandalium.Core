namespace Mandalium.Core.Abstractions.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        Task Save(CancellationToken cancellationToken = default);
        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}
