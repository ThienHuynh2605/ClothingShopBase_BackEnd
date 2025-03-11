using ClothingShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClothingShop.Infrastructure.Persistence
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ClothingShopDbContext>(options => options.UseSqlServer(connectionString));

            // Add Dependency Injection for Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        } 
    }
}
