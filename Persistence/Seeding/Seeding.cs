using Domain.Enums;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Core;

namespace Persistence.Seeding
{
    public static class DbInitializer
    {
        public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            
            await context.Database.MigrateAsync();

            if (!await context.Users.AnyAsync(u => u.UserRole == UserRole.Admin))
            {
                var salt = Guid.NewGuid().ToString("N");
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin123!" + salt);

                var admin = new User
                {
                    FullName = "System Admin",
                    Email = "admin@tastybite.com",
                    Phone = "01000000000",
                    Salt = salt,
                    HashPassword = hashedPassword,
                    UserRole = UserRole.Admin,
                    IsActive = true,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                };

                await context.Users.AddAsync(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}