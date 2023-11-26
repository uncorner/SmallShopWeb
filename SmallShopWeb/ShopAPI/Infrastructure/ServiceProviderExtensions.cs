using SmallShopWeb.ShopAPI.App;
using SmallShopWeb.ShopAPI.App.Client;
using SmallShopWeb.ShopAPI.Infrastructure.Client;

namespace SmallShopWeb.ShopAPI.Infrastructure;

internal static class ServiceProviderExtensions
{
    
    public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<ProductCatalog.ProductCatalogClient>(opt =>
            {
                opt.Address = new Uri(configuration.GetCatalogServiceUrl());
            });

        services.AddTransient<IProductCatalogClient, ProductCatalogClient>();
    }
}
