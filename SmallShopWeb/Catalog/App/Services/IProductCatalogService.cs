using Grpc.Core;

namespace SmallShopWeb.Catalog.App.Services
{
    public interface IProductCatalogService
    {
        Task<ProductListReply> GetProducts(ServerCallContext context);

    }
}
