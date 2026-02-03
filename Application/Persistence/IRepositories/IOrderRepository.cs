using Application.Common;
using Domain.Orders;
using Domain.Users;

namespace Application.Persistence.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        //Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId);
        //Task<IEnumerable<Order>> GetOrdersByGuestUserId(Guid guestUserId);

        Task<PageResult<Order>> GetAllOrdersAsync(int pageNumber, int pageSize);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<PageResult<Order>> GetOrdersByCustomerIdAsync(Guid customerId, int pageNumber, int pageSize);

    }

    public interface IGuestUserRepository : IGenericRepository<GuestUser>
    {
        Task<GuestUser?> FindByEmailOrPhoneAsync(string email, string phone);
    }

}
