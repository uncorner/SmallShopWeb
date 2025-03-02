using Google.Protobuf.WellKnownTypes;
using SmallShopWeb.ShopAPI.Application.CatalogClient;

namespace SmallShopWeb.ShopAPI.Infrastructure.GrpcClient
{
    internal class ProductCatalogClient : IProductCatalogClient
    {
        private readonly ProductCatalog.ProductCatalogClient grpcClient;

        public ProductCatalogClient(ProductCatalog.ProductCatalogClient grpcClient)
        {
            this.grpcClient = grpcClient;
        }

        public Task<ProductListReply> GetProductsAsync() =>
            grpcClient.GetProductsAsync(new Empty()).ResponseAsync;

        public Task<CreateProductsReply> CreateProductsAsync(CreateProductsRequest request) =>
            grpcClient.CreateProductsAsync(request).ResponseAsync;

        public Task<Empty> UpdateProductsAsync(UpdateProductsRequest request) =>
            grpcClient.UpdateProductsAsync(request).ResponseAsync;

        public Task<Empty> RemoveProductsAsync(RemoveProductsRequest request) =>
            grpcClient.RemoveProductsAsync(request).ResponseAsync;

    }
}
