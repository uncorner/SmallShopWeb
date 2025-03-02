namespace SmallShopWeb.ShopWeb.Util;

static class ConfigurationExtensions
{
    public static string GetShopApiServiceUrl(this IConfiguration config)
    {
        return config["ShopApiServiceUrl"]!;
    }

}
