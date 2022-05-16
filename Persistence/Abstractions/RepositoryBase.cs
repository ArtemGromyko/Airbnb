using Airbnb.DAL.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace Airbnb.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => repositoryContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            repositoryContext.Set<T>().Where(expression).AsNoTracking();

        public async Task CreateAsync(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);
            await repositoryContext.SaveChangesAsync();
        }
    }
}
