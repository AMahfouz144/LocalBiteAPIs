
using Application.Common;
using Application.Persistence.IRepositories;
using Application.Usecase.Menu.Queries;
using Application.Usecase.Products.DTOs;
using MediatR;

namespace Application.Usecase.Menu.Handler
{
    public class GetMenuHandler(IProductRepository _productRepo) : IRequestHandler<GetMenuQuery, PageResult<ProductDto>>
    {

        public async Task<PageResult<ProductDto>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            var (products, totalCount) = await _productRepo.GetActiveProductsWithCategoryPagedAsync(request.PageIndex,request.PageSize, request.Type,request.CategoryId);

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                CategoryName = p.Category?.Name
            }).ToList();

            return new PageResult<ProductDto>
            {
                Count = totalCount,
                Data = result
            };
        }
    }
}