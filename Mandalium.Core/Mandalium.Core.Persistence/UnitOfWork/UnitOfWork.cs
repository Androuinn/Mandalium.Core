﻿using Mandalium.Core.Abstractions.Interfaces;
using Mandalium.Core.Persisence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Mandalium.Core.Persisence.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private Hashtable _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        , _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}
