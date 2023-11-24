using ShopWeb.App.Client;
using SmallShopWeb.ShopCommon.Dto;

namespace ShopWeb.Infrastructure.Client;

class ShopApiClient : IShopApiClient
{
    // TODO in config settings host
    private const string BaseAddr = "http://localhost:5194";
    private readonly HttpClient httpClient;

    public ShopApiClient(HttpClient httpClient)
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
