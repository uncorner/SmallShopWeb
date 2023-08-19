using SmallShopWeb.ShopAPI.Infrastructure.Client;

namespace SmallShopWeb.ShopAPI.App.Client
{
    public interface IProductCatalogClient
    {
        Task<ProductListReply> GetProductsAsync();

    }
}
