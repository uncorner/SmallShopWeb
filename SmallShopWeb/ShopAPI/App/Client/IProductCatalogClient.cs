using Google.Protobuf.WellKnownTypes;

namespace SmallShopWeb.ShopAPI.App.Client
{
    public interface IProductCatalogClient
    {
        Task<ProductListReply> GetProductsAsync();
        Task<CreateProductsReply> CreateProductsAsync(CreateProductsRequest request);
        Task<Empty> UpdateProductsAsync(UpdateProductsRequest request);
    }
}
