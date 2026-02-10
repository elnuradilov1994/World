using System.Linq.Expressions;
using World.Entities;

namespace World.Core.DAL.Repositories.Abstract
{
    public interface IBaseRepository<TEntity>
        where TEntity : class,new()
    {
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] includes);
        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,params string[] includes);
        public Task<List<TEntity>> GetAllPaginatedAsync(int page,int size,Expression<Func<TEntity, bool>> filter = null, params string[] includes);
        public Task AddAsync(TEntity entity);
        public void RemoveAsync(TEntity entity);
        public void UpdateAsync(TEntity entity);
        public Task SaveAsync();
        public IQueryable<TEntity> GetQuery(string[] includes);
    }
}
