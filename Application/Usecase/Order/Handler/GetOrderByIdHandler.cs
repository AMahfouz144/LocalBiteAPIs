using Application.Persistence.IRepositories;
using Application.Usecase.Order.DTOs;
using Application.Usecase.Order.Queries;
using MediatR;


namespace Application.Usecase.Order.Handler
{    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponseDto?>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponseDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
                return null;

            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                DeliveryType = order.DeliveryType,
                Address = order.Address,
                Notes = order.Notes,
                CreatedAt = order.CreatedAt,
                CustomerId = order.CustomerId,
                GuestUserId = order.GuestUserId,
                Customer = order.Customer,
                GuestUser = order.GuestUser,
                OrderItems = order.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    ProductId = oi.ProductId,
                    ProductName = oi.Product.Name, 
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToList()

            };
        }
    }
}
