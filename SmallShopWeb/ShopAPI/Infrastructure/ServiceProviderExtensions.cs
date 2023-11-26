using SmallShopWeb.ShopAPI.App.Client;
using SmallShopWeb.ShopAPI.Infrastructure.Client;

namespace SmallShopWeb.ShopAPI.Infrastructure
{
    internal static class ServiceProviderExtensions
    {
        public const string CatalogServiceUrlKey = "CatalogServiceUrl";

        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            var catalogServiceUrl = configuration[CatalogServiceUrlKey]!;
            services.AddGrpcClient<ProductCatalog.ProductCatalogClient>(opt =>
                {
                    opt.Address = new Uri(catalogServiceUrl);
                });

            services.AddTransient<IProductCatalogClient, ProductCatalogClient>();
        }
    }
}
