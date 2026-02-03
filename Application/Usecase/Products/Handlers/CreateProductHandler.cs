using Application.Common;
using Application.Exceptions;
using Application.Persistence.IRepositories;
using Application.Usecase.Products.Commands;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Usecase.Products.Handlers
{
    public class CreateProductHandler : BaseHandler<CreateProductCommand, Guid>
    {

        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository; 
        private readonly IDatabaseRepository _databaseRepository;

        public CreateProductHandler(
            IProductRepository repository,
            ICategoryRepository categoryRepository,
            IDatabaseRepository databaseRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _databaseRepository = databaseRepository;
        }


        protected async override Task<Guid> HandleValidated(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException($"Category with Id {request.CategoryId} was not found");

    
            var product = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ImageUrl = request.ImageUrl ?? string.Empty,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.AddAsync(product);
            await _databaseRepository.SaveChangesAsync();

            return product.Id;
        }
    }
}