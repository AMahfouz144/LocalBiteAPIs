
using Application.Persistence.IRepositories;
using Application.Usecase.Products.DTOs;
using Application.Usecase.Products.Queries;
using MediatR;

namespace Application.Usecase.Products.Handlers
{

    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductResponseDto>
    {
        private readonly IProductRepository _repository;

        public GetProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponseDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
                return null;

            return new ProductResponseDto
            {
                Id= product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                IsActive = product.IsActive
            };
        }

    }
}
