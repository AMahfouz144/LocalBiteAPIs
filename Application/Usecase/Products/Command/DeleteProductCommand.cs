using Application.Common;
using MediatR;

namespace Application.Usecase.Products.Commands
{
    //public record DeleteProductCommand(Guid Id) : IRequest<bool>;
    public class DeleteProductCommand : BaseModel,IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}