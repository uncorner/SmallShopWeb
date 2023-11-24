using SmallShopWeb.ShopCommon.Dto;

namespace ShopWeb.App.Client;

public interface IShopApiClient
{
    Task<IEnumerable<ProductInfo>?> GetProductsAsync();
}
