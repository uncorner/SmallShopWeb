namespace SmallShopWeb.ShopAPI.App;

static class ConfigurationExtensions
{
    public static string GetCatalogServiceUrl(this IConfiguration config)
    {
        return config["CatalogServiceUrl"]!;
    }

}
