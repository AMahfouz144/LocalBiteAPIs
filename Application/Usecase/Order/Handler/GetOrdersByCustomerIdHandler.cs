using Application.Common;
using Application.Persistence.IRepositories;
using Application.Usecase.Order.DTOs;
using Application.Usecase.Order.Queries;
using MediatR;

namespace Application.Usecase.Order.Handlers
{
    public class GetOrdersByCustomerIdHandler: IRequestHandler<GetOrdersByCustomerIdQuery, PageResult<OrderResponseDto>>
    {
        private readonly IOrderRepository _repository;

        public GetOrdersByCustomerIdHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PageResult<OrderResponseDto>> Handle(GetOrdersByCustomerIdQuery request,CancellationToken cancellationToken)
        {
            var result = await _repository.GetOrdersByCustomerIdAsync(request.CustomerId, request.PageIndex, request.PageSize);
           
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