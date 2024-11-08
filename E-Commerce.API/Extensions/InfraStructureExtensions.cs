global using Microsoft.EntityFrameworkCore;
global using Domain.Contracts;
global using Persistence.Repositories;
global using Persistence;
global using Persistence.Data;

namespace E_Commerce.API.Extensions
{
    public static class InfraStructureExtensions
    {
        
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection"));
            });

            return services;
        }
    }
}
