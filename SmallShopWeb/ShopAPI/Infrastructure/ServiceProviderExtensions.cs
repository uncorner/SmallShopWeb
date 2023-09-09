using SmallShopWeb.ShopAPI.App.Client;
using SmallShopWeb.ShopAPI.Infrastructure.Client;

namespace SmallShopWeb.ShopAPI.Infrastructure
{
    internal static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddGrpcClient<ProductCatalog.ProductCatalogClient>(opt =>
                {
                    opt.Address = new Uri("http://localhost:7240");
                });

            services.AddTransient<IProductCatalogClient, ProductCatalogClient>();
        }
    }
}
