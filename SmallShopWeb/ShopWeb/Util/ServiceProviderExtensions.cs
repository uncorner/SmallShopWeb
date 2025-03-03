using Polly;
using SmallShopWeb.ShopWeb.Application;
using SmallShopWeb.ShopWeb.Infrastructure.WebClient;

namespace SmallShopWeb.ShopWeb.Util;

static class ServiceProviderExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddHttpClient<IShopApiClient, ShopApiClient>()
            .AddTransientHttpErrorPolicy(policy =>
                policy.WaitAndRetryAsync(new[] {
                TimeSpan.FromMilliseconds(200),
                TimeSpan.FromMilliseconds(500),
                TimeSpan.FromSeconds(1)
                })
            );
    }

}
