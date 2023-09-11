using SmallShopWeb.ShopAPI.App.Client;
using SmallShopWeb.ShopAPI.Infrastructure.Client;

namespace SmallShopWeb.ShopAPI.Infrastructure
{
    internal static class ServiceProviderExtensions
    {
        public const string CatalogServiceUrlKey = "CatalogServiceUrl";

        public static void AddCustomServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            var catalogServiceUrl = configuration[CatalogServiceUrlKey]
                ?? throw new NullReferenceException($"configuration key {CatalogServiceUrlKey} is null");
            services.AddGrpcClient<ProductCatalog.ProductCatalogClient>(opt =>
                {
                    opt.Address = new Uri(catalogServiceUrl);
                });

            services.AddTransient<IProductCatalogClient, ProductCatalogClient>();
        }
    }
}
