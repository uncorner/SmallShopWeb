using SmallShopWeb.ShopCommon.Dto;
using SmallShopWeb.ShopWeb.Application;
using SmallShopWeb.ShopWeb.Application.Client;
using SmallShopWeb.ShopWeb.Util;

namespace SmallShopWeb.ShopWeb.Infrastructure.Client;

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
