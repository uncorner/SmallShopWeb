using SmallShopWeb.ShopAPI.Protos;

namespace SmallShopWeb.ShopAPI.App
{
    internal static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            //services.AddHttpClient<ICatalogClient, CatalogClient>()
            //    .AddTransientHttpErrorPolicy(policy =>
            //        policy.WaitAndRetryAsync(new[] {
            //        TimeSpan.FromMilliseconds(200),
            //        TimeSpan.FromMilliseconds(500),
            //        TimeSpan.FromSeconds(1)
            //        })
            //    );

            services.AddGrpcClient<ProductCatalog.ProductCatalogClient>(opt =>
            {
                opt.Address = new Uri("https://localhost:7240");
            });
        }
    }
}
