using Application.Common;
using Application.Exceptions;
using Application.Persistence.IRepositories;
using Application.Usecase.Products.Commands;

namespace Application.Usecase.Products.Handlers
{


    public class UpdateProductHandler : BaseHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly IDatabaseRepository _databaseRepository;
        public UpdateProductHandler(IProductRepository repository, IDatabaseRepository databaseRepository)
        {
            _repository = repository;
            _databaseRepository = databaseRepository;
        }

        protected async override Task<bool> HandleValidated(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
                throw new NotFoundException("Product not found");


            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            product.ImageUrl = request.ImageUrl;
            product.IsActive = request.IsActive;

            await _repository.UpdateAsync(product);
            await _databaseRepository.SaveChangesAsync();

            return true;
        }
    }
}