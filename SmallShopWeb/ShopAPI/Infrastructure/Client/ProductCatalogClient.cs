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

        public async Task<CreateProductsReply> CreateProducts(CreateProductsRequest request)
        {
            return await client.CreateProductsAsync(request);
        }

    }
}
