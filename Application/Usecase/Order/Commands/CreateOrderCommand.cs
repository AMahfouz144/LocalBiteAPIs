using Application.Usecase.Order.DTOs;
using MediatR;

namespace Application.Usecase.Order.Command
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public CreateOrderDto Order { get; set; }
    }

}
