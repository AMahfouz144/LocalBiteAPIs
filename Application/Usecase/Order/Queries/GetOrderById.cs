using Application.Usecase.Order.DTOs;
using MediatR;

namespace Application.Usecase.Order.Queries
{
    

    public class GetOrderByIdQuery : IRequest<OrderResponseDto?>
    {
        public Guid OrderId { get; set; }
    }
}
