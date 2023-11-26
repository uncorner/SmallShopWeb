namespace SmallShopWeb.ShopWeb.App;

static class ConfigurationExtensions
{
    public static string GetShopApiServiceUrl(this IConfiguration config)
    {
        return config["ShopApiServiceUrl"]!;
    }

}
