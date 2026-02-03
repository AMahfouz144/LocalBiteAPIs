using Application.Common;
using Application.Usecase.Order.DTOs;
using MediatR;
namespace Application.Usecase.Order.Queries
{

    public class GetAllOrdersQuery : IRequest<PageResult<OrderResponseDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
