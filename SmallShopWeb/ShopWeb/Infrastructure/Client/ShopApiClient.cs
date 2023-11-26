using ShopWeb.App.Client;
using SmallShopWeb.ShopCommon.Dto;
using SmallShopWeb.ShopWeb.App;

namespace ShopWeb.Infrastructure.Client;

class ShopApiClient : IShopApiClient
{
    private readonly HttpClient httpClient;

    public ShopApiClient(HttpClient httpClient, IConfiguration config)
    {
        this.httpClient = httpClient;
        this.httpClient.BaseAddress = new Uri(config.GetShopApiServiceUrl());
    }

    public async Task<IEnumerable<ProductInfo>?> GetProductsAsync()
    {
        return await httpClient.GetFromJsonAsync<ProductInfo[]>("api/products");
    }

}
