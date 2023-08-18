using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.Catalog.Infrastructure;
using SmallShopWeb.Catalog.Infrastructure.Repository;

namespace SmallShopWeb.Catalog.App
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
