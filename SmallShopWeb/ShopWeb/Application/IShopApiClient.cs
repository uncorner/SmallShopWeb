using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopWeb.Application;

public interface IShopApiClient
{
    Task<IEnumerable<ProductInfo>?> GetProductsAsync();
}
