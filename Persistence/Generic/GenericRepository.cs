using Application.Persistence.IRepositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public abstract class GenericRepository : IGenericRepository { }

    public class GenericRepository<T> : GenericRepository, IGenericRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> dbSet;

        protected GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        // Create
        public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);
        public async Task AddRangeAsync(List<T> entities) => await dbSet.AddRangeAsync(entities);

        // Delete
        public void Remove(T entity) => dbSet.Remove(entity);
        public void RemoveRange(List<T> entities) => dbSet.RemoveRange(entities);

        // Update
        public void Update(T entity) => dbSet.Update(entity);
        public Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public void UpdateRange(List<T> entities) => dbSet.UpdateRange(entities);

        // Read
        public async Task<T> GetByIdAsync(object id) => await dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAsync() => await dbSet.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression) => await dbSet.Where(expression).ToListAsync();
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => await dbSet.AnyAsync(expression);
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression) => await dbSet.FirstOrDefaultAsync(expression);

        // Queryable
        public IQueryable<T> AsQueryable() => dbSet.AsQueryable();
        public IQueryable<T> AsNoTracking() => dbSet.AsNoTracking();

        // Paging
        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            Expression<Func<T, bool>>? filter,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            int pageIndex,
            int pageSize,
            bool asNoTracking = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (asNoTracking)
                query = query.AsNoTracking();

            var totalCount = await query.CountAsync();

            if (orderBy != null)
                query = orderBy(query);

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        // Count
        public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter != null)
                return await dbSet.CountAsync(filter);

            return await dbSet.CountAsync();
        }
    }
}