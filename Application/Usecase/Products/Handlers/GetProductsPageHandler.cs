

using Application.Common;
using Application.Persistence.IRepositories;
using Application.Usecase.Products.DTOs;
using Application.Usecase.Products.Queries;
using MediatR;

namespace Application.Usecase.Products.Handlers
{
    public class GetProductsPageHandler : IRequestHandler<GetProductsPageQuery, PageResult<ProductResponseDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductsPageHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PageResult<ProductResponseDto>> Handle(GetProductsPageQuery request, CancellationToken cancellationToken)
        {
            var page = await _repository.GetPagedAsync(null, null,request.PageIndex,request.PageSize,  true);
          

            var result = new PageResult<ProductResponseDto>
            {

                Count = page.TotalCount,
                Data = page.Items.Select(a => new ProductResponseDto
                {
                    Id=a.Id,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    CategoryId = a.CategoryId,
                    Description = a.Description,
                    Name = a.Name,
                    IsActive = a.IsActive,
                }).ToList()
            };
            return result;
        }
    }
}