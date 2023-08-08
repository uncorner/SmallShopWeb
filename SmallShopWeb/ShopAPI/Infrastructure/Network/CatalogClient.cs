using SmallShopWeb.ShopAPI.App.Network;
using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopAPI.Infrastructure.Network
{
    internal class CatalogClient : ICatalogClient
    {
        private const string BaseAddr = "http://localhost:5239";
        private readonly HttpClient httpClient;

        public CatalogClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            // todo: https
            this.httpClient.BaseAddress = new Uri(BaseAddr);
        }

        public async Task<IEnumerable<ProductInfo>?> GetProductsAsync()
        {
            return await httpClient.GetFromJsonAsync<ProductInfo[]>("api/products");
        }

    }
}
