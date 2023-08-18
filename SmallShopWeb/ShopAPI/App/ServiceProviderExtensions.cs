using SmallShopWeb.ShopAPI.Infrastructure.Client;

namespace SmallShopWeb.ShopAPI.App
{
    internal static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddGrpcClient<ProductCatalog.ProductCatalogClient>(opt =>
                {
                    opt.Address = new Uri("https://localhost:7240");
                });
        }
    }
}
