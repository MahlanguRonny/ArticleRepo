using ArenaHoldings.ArticleManagement.Api.DataEntities;
using ArenaHoldings.ArticleManagement.Api.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected ArticleContext articleContext;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ArticleContext articleContext, ILogger logger)
        {
            this.articleContext = articleContext;
            this.dbSet = articleContext.Set<T>();
            this._logger = logger;
        }

        public virtual Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> CreateOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

    }
}
