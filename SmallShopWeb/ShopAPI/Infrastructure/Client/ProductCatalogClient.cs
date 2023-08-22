using Google.Protobuf.WellKnownTypes;
using SmallShopWeb.ShopAPI.App.Client;

namespace SmallShopWeb.ShopAPI.Infrastructure.Client
{
    internal class ProductCatalogClient : IProductCatalogClient
    {
        private readonly ProductCatalog.ProductCatalogClient client;

        public ProductCatalogClient(ProductCatalog.ProductCatalogClient client)
        {
            this.client = client;
        }

        public async Task<ProductListReply> GetProductsAsync()
        {
            return await client.GetProductsAsync(new Empty());
        }

        public async Task<CreateProductsReply> CreateProductsAsync(CreateProductsRequest request)
        {
            return await client.CreateProductsAsync(request);
        }

        public async Task<Empty> UpdateProductsAsync(UpdateProductsRequest request)
        {
            return await client.UpdateProductsAsync(request);
        }

    }
}
