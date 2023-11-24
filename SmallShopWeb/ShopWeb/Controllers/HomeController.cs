using Microsoft.AspNetCore.Mvc;
using ShopWeb.App.Client;
using SmallShopWeb.ShopCommon.Dto;
using SmallShopWeb.ShopWeb.Presentation.Models;
using System.Diagnostics;

namespace SmallShopWeb.ShopWeb.Controllers;

public class HomeController : Controller
{
    private readonly IShopApiClient apiClient;

    public HomeController(IShopApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        //>>>>>>>>>
        var result = await apiClient.GetProductsAsync();
        IEnumerable<ProductInfo> products = result ?? Array.Empty<ProductInfo>();
        ProductListModel model = new() { Produts = products };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}