using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace SmallShopWeb.Catalog.App.Services
{
    public interface IProductCatalogService
    {
        Task<ProductListReply> GetProducts(ServerCallContext context);
        Task<CreateProductsReply> CreateProducts(CreateProductsRequest request, ServerCallContext context);
        Task<Empty> UpdateProducts(UpdateProductsRequest request, ServerCallContext context);
        Task<Empty> RemoveProducts(RemoveProductsRequest request, ServerCallContext context);

    }
}
