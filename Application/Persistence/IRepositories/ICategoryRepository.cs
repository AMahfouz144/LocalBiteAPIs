using Application.Common;
using Application.Persistence.IRepositories;
using Domain.Categories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetByIdAsync(Guid id);
    Task<PageResult<Category>> GetPagedAsync(int pageIndex, int pageSize, bool asNoTracking = true);
    Task<(List<Category> Items, int TotalCount)> GetCategoriesWithProductsPagedAsync(int pageIndex, int pageSize);

}
