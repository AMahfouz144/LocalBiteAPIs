using Application.Persistence.IRepositories;
using Domain.Interfaces;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;
using System.Security.Claims;

namespace Persistence.Repositories
{
    public class UserRepository(AppDbContext _context, IHttpContextAccessor _httpContextAccessor) : GenericRepository<User>(_context),IUserRepository
    {

        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> IsAuthenticated()
        {
            var httpUser = _httpContextAccessor.HttpContext?.User;

            if (httpUser == null || !httpUser.Identity?.IsAuthenticated == true)
                throw new UnauthorizedAccessException("User is not authenticated.");

            // Example: resolve from claim
            var email = httpUser.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("Email claim not found.");

            var user = await GetByEmailAsync(email);

            if (user == null)
                throw new UnauthorizedAccessException("User not found in database.");

            return user;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}