using Polly;
using ShopWeb.App.Client;
using ShopWeb.Infrastructure.Client;

namespace SmallShopWeb.ShopWeb.Infrastructure;

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
