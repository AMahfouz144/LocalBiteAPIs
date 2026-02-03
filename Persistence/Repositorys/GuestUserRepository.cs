using Application.Persistence.IRepositories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class GuestUserRepository : GenericRepository<GuestUser>, IGuestUserRepository
    {
        private readonly AppDbContext _context;
        public GuestUserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GuestUser?> FindByEmailOrPhoneAsync(string email, string phone) =>
            await _context.GuestUsers.FirstOrDefaultAsync(g => g.Email == email || g.Phone == phone);

        public async Task<GuestUser> AddAsync(GuestUser guest)
        {
            _context.GuestUsers.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }
    }

}
