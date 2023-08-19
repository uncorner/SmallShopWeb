using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.Catalog.App.Services;
using SmallShopWeb.Catalog.Infrastructure.Repository;

namespace SmallShopWeb.Catalog.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();

            var connectionString = configuration.GetConnectionString("Default")
                ?? throw new NullReferenceException("Cannot get connection string");
            services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddTransient<IProductCatalogService, ProductCatalogService>();
        }

    }
}
