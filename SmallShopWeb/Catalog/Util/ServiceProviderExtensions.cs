using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.Application.Repository;
using SmallShopWeb.Catalog.Infrastructure.Persistence;
using SmallShopWeb.Catalog.Infrastructure.Persistence.Repository;
using SmallShopWeb.Catalog.Presentation.GrpcService;

namespace SmallShopWeb.Catalog.Util
{
    public static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            
            var connectionString = configuration.GetConnectionString("Default")
                ?? throw new NullReferenceException("Cannot get connection string");
            services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));
        }

    }
}
