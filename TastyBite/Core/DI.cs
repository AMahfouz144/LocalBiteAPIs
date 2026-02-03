    using Application;
    using Domain.Interfaces;
    using Infrastracture.Configurations;
    using Persistence.Core;
using Infrastracture.Core;
using Infrastructure.Services;

namespace API.Core
    {
        public static class DI
        {
            public static WebApplicationBuilder ConfigareAPI(this WebApplicationBuilder builder)
            {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.SetIsOriginAllowed(origin =>
                    {
                        var uri = new Uri(origin);

                        return uri.Host == "localhost" || uri.Host != null;
                    })
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });


            builder.Services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
                });
                builder.Services.Configure<JwtConfiguration>(
                builder.Configuration.GetSection("Jwt"));

             builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.RegisterInfrastructure(builder.Configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.RegisterPersistence(builder.Configuration);
                return builder;
            }
        }
    }