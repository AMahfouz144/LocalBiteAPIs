
using Application.Common;
using Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;
using Persistence.Repositories;

namespace Persistence.Repositorys
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await context.Set<Category>()
                                .AsNoTracking()
                                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<(List<Category> Items, int TotalCount)> GetCategoriesWithProductsPagedAsync(int pageIndex, int pageSize)
        {
            var query = context.Categories
                .Include(c => c.Products)   
                .Where(c => c.IsActive);    

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Name)       
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }


        public async Task<PageResult<Category>> GetPagedAsync(int pageIndex, int pageSize, bool asNoTracking = true)

        {
            var query = context.Set<Category>().AsQueryable();
            if (asNoTracking) query = query.AsNoTracking();

            var total = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.sortOrder).ThenBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<Category>
            {
                Data = items,
                Count = total,
            };
        }
    }
}
