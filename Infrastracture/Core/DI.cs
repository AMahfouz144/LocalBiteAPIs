using Application.Infrastructure;
using Infrastracture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastracture.Core
{
   public static class DI
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IFileStorageService, FileStorageService>();
        }
    }
}
