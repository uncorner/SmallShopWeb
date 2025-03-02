using SmallShopWeb.ShopAPI.Application.CatalogClient;
using SmallShopWeb.ShopAPI.Infrastructure.GrpcClient;

namespace SmallShopWeb.ShopAPI.Util;

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
