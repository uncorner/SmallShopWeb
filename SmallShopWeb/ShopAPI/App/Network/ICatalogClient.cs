using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopAPI.App.Network
{
    public interface ICatalogClient
    {
        Task<IEnumerable<ProductInfo>?> GetProductsAsync();
    }
}