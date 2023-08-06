using SmallShopWeb.ShopCommon.Models;

namespace SmallShopWeb.ShopAPI.App.Network
{
    public interface ICatalogClient
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
    }
}