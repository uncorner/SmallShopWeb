using Grpc.Core;

namespace SmallShopWeb.Catalog.App.Services
{
    public interface IProductCatalogService
    {
        Task<ProductListReply> GetProducts(ServerCallContext context);
        Task<CreateProductsReply> CreateProducts(CreateProductsRequest request, ServerCallContext context);
    }
}
