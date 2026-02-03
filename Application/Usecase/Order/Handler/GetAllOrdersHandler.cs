using Application.Common;
using Application.Persistence.IRepositories;
using Application.Usecase.Order.DTOs;
using Application.Usecase.Order.Queries;
using MediatR;

namespace Application.Usecase.Order.Handler
{
   
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, PageResult<OrderResponseDto>>
    {
        private readonly IOrderRepository _repository;

        public GetAllOrdersHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PageResult<OrderResponseDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllOrdersAsync(request.PageIndex, request.PageSize);

            return new PageResult<OrderResponseDto>
            {
                Count = result.Count,
                Data = result.Data.Select(o => new OrderResponseDto
                {
                    OrderId = o.OrderId,
                    TotalPrice = o.TotalPrice,
                    OrderStatus = o.OrderStatus,
                    DeliveryType = o.DeliveryType,
                    Address = o.Address,
                    Notes = o.Notes,
                    CreatedAt = o.CreatedAt,
                    CustomerId = o.CustomerId,
                    GuestUserId = o.GuestUserId,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemResponseDto
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name, 
                        Quantity = oi.Quantity,
                        Price = oi.Price
                    }).ToList()

                }).ToList()
            };
        }
    }
}
