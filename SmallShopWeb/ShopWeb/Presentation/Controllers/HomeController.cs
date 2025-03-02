using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopCommon.Dto;
using SmallShopWeb.ShopWeb.Application.Client;
using SmallShopWeb.ShopWeb.Presentation.Models;

namespace SmallShopWeb.ShopWeb.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IShopApiClient apiClient;

    public HomeController(IShopApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        var result = await apiClient.GetProductsAsync();
        IEnumerable<ProductInfo> products = result ?? Array.Empty<ProductInfo>();
        ProductListModel model = new() { Products = products };

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