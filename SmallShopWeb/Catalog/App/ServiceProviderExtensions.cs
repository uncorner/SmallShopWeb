using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.Catalog.Infrastructure.Repository;

namespace SmallShopWeb.Catalog.App
{
    public static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }

    }
}
