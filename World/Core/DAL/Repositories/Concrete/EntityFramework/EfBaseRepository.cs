using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using World.Core.DAL.Repositories.Abstract;
using World.DAL;
using World.Entities;

namespace World.Core.DAL.Repositories.Concrete.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class,new()
        where TContext: DbContext
    {
        private readonly TContext _context;
        public EfBaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = GetQuery(includes);
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = GetQuery(includes);
            return filter == null
                ? await query.ToListAsync()
                : await query.Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = GetQuery(includes);
            return filter == null
                ? await query.Skip((page - 1) * size).Take(size).ToListAsync()
                : await query.Skip((page - 1) * size).Take(size).Where(filter).ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

       public void RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetQuery(string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
