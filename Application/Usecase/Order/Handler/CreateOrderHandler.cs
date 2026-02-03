
using Application.Persistence.IRepositories;
using Application.Usecase.Order.Command;
using Domain.Enums;
using Domain.Orders;
using Domain.Users;
using MediatR;

namespace Application.Usecase.Order.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IGuestUserRepository _guestRepo;
        private readonly IUserRepository _userRepo;
        private readonly IDatabaseRepository _databaseRepo;

        public CreateOrderHandler(IOrderRepository orderRepo, IGuestUserRepository guestRepo, IUserRepository userRepo, IDatabaseRepository databaseRepo)
        {
            _orderRepo = orderRepo;
            _guestRepo = guestRepo;
            _userRepo = userRepo;
            _databaseRepo = databaseRepo;

        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Order;

            var order = new Domain.Orders.Order
            {
                OrderId = Guid.NewGuid(),
                Address = dto.Address,
                Notes = dto.Notes,
                TotalPrice = dto.Items.Sum(i => i.Price * i.Quantity),
                OrderStatus = OrderStatus.Pending,
                DeliveryType = DeliveryType.Delivery,
                CreatedAt = DateTime.UtcNow,
                OrderItems = new List<OrderItems>() 
            };

            try
            {
                //var user = await _userRepo.GetByEmailAsync(dto.GuestEmail);
                var currentUser = await _userRepo.IsAuthenticated();
                order.CustomerId = currentUser.Id;
            }
            catch (UnauthorizedAccessException)
            {
                var guest = await _guestRepo.FindByEmailOrPhoneAsync(dto.GuestEmail, dto.GuestPhone);

                if (guest == null)
                {
                    guest = new GuestUser
                    {
                        Id = Guid.NewGuid(),
                        Email = dto.GuestEmail,
                        Phone = dto.GuestPhone,
                        Name = dto.GuestName
                    };
                    await _guestRepo.AddAsync(guest);
                }

                order.GuestUserId = guest.Id;
            }

            foreach (var item in dto.Items)
            {
                order.OrderItems.Add(new OrderItems
                {
                    Id = Guid.NewGuid(),
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    OrderId = order.OrderId
                });
            }

            await _orderRepo.AddAsync(order);

            await _databaseRepo.SaveChangesAsync();

            return order.OrderId;
        }
    }
}