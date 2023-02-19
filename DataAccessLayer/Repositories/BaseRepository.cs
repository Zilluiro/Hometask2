using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> FilterById(int id)
        {
            return _dbContext.Set<T>().Where(x => x.Id == id);
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> List()
        {
            return _dbContext.Set<T>();
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public async Task<T> InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
