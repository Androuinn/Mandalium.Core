namespace Mandalium.Core.Abstractions.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        Task Save();
        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}
