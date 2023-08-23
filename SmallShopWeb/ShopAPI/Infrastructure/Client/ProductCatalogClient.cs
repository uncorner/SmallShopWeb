using Google.Protobuf.WellKnownTypes;
using SmallShopWeb.ShopAPI.App.Client;

namespace SmallShopWeb.ShopAPI.Infrastructure.Client
{
    internal class ProductCatalogClient : IProductCatalogClient
    {
        private readonly ProductCatalog.ProductCatalogClient grpcClient;

        public ProductCatalogClient(ProductCatalog.ProductCatalogClient grpcClient)
        {
            this.grpcClient = grpcClient;
        }

        public async Task<ProductListReply> GetProductsAsync()
        {
            return await grpcClient.GetProductsAsync(new Empty());
        }

        public async Task<CreateProductsReply> CreateProductsAsync(CreateProductsRequest request)
        {
            return await grpcClient.CreateProductsAsync(request);
        }

        public async Task<Empty> UpdateProductsAsync(UpdateProductsRequest request)
        {
            return await grpcClient.UpdateProductsAsync(request);
        }

        public async Task<Empty> RemoveProductsAsync(RemoveProductsRequest request)
        {
            return await grpcClient.RemoveProductsAsync(request);
        }

    }
}
