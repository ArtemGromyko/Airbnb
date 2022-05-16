using System.Linq.Expressions;

namespace Airbnb.DAL.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}