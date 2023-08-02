using SmallShopWeb.ShopCommon.App;

namespace SmallShopWeb.ShopAPI.App
{
    public interface ICatalogClient
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
    }
}