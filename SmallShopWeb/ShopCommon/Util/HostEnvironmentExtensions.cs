using Microsoft.Extensions.Hosting;

namespace SmallShopWeb.ShopCommon.Util;

public static class HostEnvironmentExtensions
{

    public static bool IsDevelopmentNoSSL(this IHostEnvironment hostEnv)
    {
        return hostEnv.IsEnvironment("DevelopmentNoSSL") 
            || hostEnv.IsEnvironment("DockerDev");
    }

}
