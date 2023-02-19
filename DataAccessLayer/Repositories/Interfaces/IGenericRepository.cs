using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> FilterById(int id);

        IQueryable<T> List();

        IQueryable<T> List(Expression<Func<T, bool>> predicate);

        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
