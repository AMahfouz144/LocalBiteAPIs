using Application.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositorys;

namespace Persistence.Core
{
    public static class DI
    {
        public static void RegisterPersistence(this IServiceCollection services, IConfiguration config)
        {
            var connection=config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Common
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IDatabaseRepository, DatabaseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGuestUserRepository, GuestUserRepository>();
        }
    }
}