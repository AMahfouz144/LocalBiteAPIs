
using Application.Common;
using Domain.Categories;
using Domain.Products;

namespace Application.Persistence.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetByNameAsync(string name);
        //Task<(List<Product> Items, int TotalCount)> GetActiveProductsWithCategoryPagedAsync(int pageIndex, int pageSize);
        public Task<(List<Product> Products, int TotalCount)> GetActiveProductsWithCategoryPagedAsync(int pageIndex, int pageSize,string? type = null,Guid? categoryId = null);
        

    }
}