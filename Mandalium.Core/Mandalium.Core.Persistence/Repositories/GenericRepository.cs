using Mandalium.Core.Abstractions.Interfaces;
using Mandalium.Core.Generic.Collections;
using Mandalium.Core.Persisence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Mandalium.Core.Persisence.Repositories
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

        public async Task Delete<Type>(Type id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete == null) { return; }

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }
        public async Task<T> Get<Type>(Type id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAll(ISpecification<T> specification) => await ApplySpecification(specification).ToListAsync();
        public async Task<PagedCollection<T>> GetAllPaged(ISpecification<T> specification)
        {
            var list = await ApplySpecification(specification).ToListAsync();
            int count = await ApplySpecification(specification).CountAsync();
          
            return new PagedCollection<T>(count,list);
        }

        public async Task Save(T entity) => await _dbSet.AddAsync(entity);

        public async Task Update(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            });
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }
    }
}
