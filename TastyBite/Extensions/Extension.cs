using Persistence.Seeding;

namespace Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task UseDatabaseSeeding(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            await DbInitializer.SeedAdminAsync(services);
        }
    }
}