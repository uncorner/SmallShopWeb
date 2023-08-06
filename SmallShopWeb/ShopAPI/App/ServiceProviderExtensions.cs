using Polly;
using SmallShopWeb.ShopAPI.App.Network;
using SmallShopWeb.ShopAPI.Infrastructure.Network;

namespace SmallShopWeb.ShopAPI.App
{
    internal static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddHttpClient<ICatalogClient, CatalogClient>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[] {
                    TimeSpan.FromMilliseconds(200),
                    TimeSpan.FromMilliseconds(500),
                    TimeSpan.FromSeconds(1)
                    })
                );
        }
    }
}
