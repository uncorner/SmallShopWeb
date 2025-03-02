namespace SmallShopWeb.ShopAPI.Util;

static class ConfigurationExtensions
{
    public static string GetCatalogServiceUrl(this IConfiguration config)
    {
        return config["CatalogServiceUrl"]!;
    }

}
