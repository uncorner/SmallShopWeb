using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopWeb.Application.Client;

public interface IShopApiClient
{
    Task<IEnumerable<ProductInfo>?> GetProductsAsync();
}
