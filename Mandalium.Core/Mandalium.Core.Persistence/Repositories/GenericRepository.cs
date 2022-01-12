using Mandalium.Core.Abstractions.Interfaces;
using Mandalium.Core.Generic.Collections;
using Mandalium.Core.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using Mandalium.Core.Persistence.Helper;

namespace Mandalium.Core.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Delete<Type>(Type id, CancellationToken cancellationToken = default)
        {
            T entityToDelete = await _dbSet.FindAsync(id, cancellationToken);
            if (entityToDelete == null) { return; }

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }
        public async Task<T> Get<Type>(Type id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(id, cancellationToken);

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default) => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IEnumerable<T>> GetAll(ISpecification<T> specification, CancellationToken cancellationToken = default) => await ApplySpecification(specification).AsNoTracking().ToListAsync(cancellationToken);
        public async Task<PagedCollection<T>> GetAllPaged(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var list = await ApplySpecification(specification).AsNoTracking().ToListAsync(cancellationToken);
            int count = await ApplySpecification(specification.GetWithoutPaging()).CountAsync(cancellationToken);

            return new PagedCollection<T>(count, specification.Take, specification.PageIndex, list);
        }

        public async Task Save(T entity, CancellationToken cancellationToken = default) => await _dbSet.AddAsync(entity, cancellationToken);

        public async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }, cancellationToken);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }

        public async Task Detach(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                _context.Entry(entity).State = EntityState.Detached;
            }, cancellationToken);

        }
    }
}
