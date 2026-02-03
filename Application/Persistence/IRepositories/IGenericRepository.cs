using Domain.Common;
using System.Linq.Expressions;

namespace Application.Persistence.IRepositories
{
    public interface IGenericRepository { }

    public interface IGenericRepository<T> : IGenericRepository where T : class, IEntity
    {
        // Create
        Task AddAsync(T entity);
        //Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);

        // Read
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        // Update
        void Update(T entity);
        Task UpdateAsync(T entity);
        void UpdateRange(List<T> entities);

        // Delete
        void Remove(T entity);
        void RemoveRange(List<T> entities);

        // Tracking control
        IQueryable<T> AsQueryable(); // يسمح بالاستعلامات المتقدمة
        IQueryable<T> AsNoTracking(); // استعلام بدون تتبع

        // Paging
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            Expression<Func<T, bool>>? filter,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            int pageIndex,
            int pageSize,
            bool asNoTracking = true);

        // Count
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
    }
}