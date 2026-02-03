using Application.Persistence.IRepositories;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<(List<Product> Products, int TotalCount)> GetActiveProductsWithCategoryPagedAsync(int pageIndex,int pageSize,string? type = null, Guid? categoryId = null)
        {
            var query = context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive);

            //if (!string.IsNullOrEmpty(type))
            //    query = query.Where(p => p.Type == type);

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            var totalCount = await query.CountAsync();

            var products = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            return (products, totalCount);
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Name == name);
            //return await context.Set<Product>().FirstOrDefaultAsync(p => p.Name == name);
        }
       


    }
}