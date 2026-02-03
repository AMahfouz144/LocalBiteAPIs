using Application.Common;
using Application.Persistence.IRepositories;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;
using Persistence.Repositories;


namespace Persistence.Repositorys
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId) =>
            await dbSet.Where(o => o.CustomerId == customerId).ToListAsync();

        public async Task<IEnumerable<Order>> GetOrdersByGuestUserId(Guid guestUserId) =>
            await dbSet.Where(o => o.GuestUserId == guestUserId).ToListAsync();
        public async Task<PageResult<Order>> GetAllOrdersAsync(int pageNumber, int pageSize)
        {
            var query = context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product);

            var count = await query.CountAsync();
            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<Order> { Data = data, Count = count };
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<PageResult<Order>> GetOrdersByCustomerIdAsync(Guid customerId, int pageNumber, int pageSize)
        {
            var query = context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId);

            var count = await query.CountAsync();
            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<Order> { Data = data, Count = count };
        }
    }

}
