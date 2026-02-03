using Application.Common;
using Application.Exceptions;
using Application.Persistence.IRepositories;
using Application.Usecase.Products.Commands;
using MediatR;

namespace Application.Usecase.Products.Handlers
{
    public class DeleteProductHandler(IProductRepository _repository, IDatabaseRepository database) : BaseHandler<DeleteProductCommand, bool>
    {
        protected async override Task<bool> HandleValidated(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
                throw new NotFoundException("Product Not Found");


            _repository.Remove(product);
            await database.SaveChangesAsync();
            return true;
        }
    }

}
