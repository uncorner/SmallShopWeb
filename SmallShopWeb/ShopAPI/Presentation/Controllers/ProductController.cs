using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopAPI.Application.CatalogClient;
using SmallShopWeb.ShopCommon.Dto;
using CreateProductData = SmallShopWeb.ShopAPI.Presentation.Models.CreateProductData;
using UpdateProductData = SmallShopWeb.ShopAPI.Presentation.Models.UpdateProductData;

namespace SmallShopWeb.ShopAPI.Presentation.Controllers;

[Route("api")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductCatalogClient catalogClient;
    private readonly ILogger<ProductController> logger;

    public ProductController(IProductCatalogClient catalogClient, ILogger<ProductController> logger)
    {
        this.catalogClient = catalogClient;
        this.logger = logger;
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        return await this.HandleErrors(logger, async () =>
        {
            var listReply = await catalogClient.GetProductsAsync();

            var productInfos = listReply.Products.Select(p =>
                new ProductInfo(p.Id, p.Name, p.Description, p.Price)).ToArray();

            return Ok(productInfos);
        });
    }

    [HttpPost("products")]
    public async Task<IActionResult> CreateProducts([FromBody] CreateProductData[] datas)
    {
        return await this.HandleErrors(logger, async () =>
        {
            var productDatas = datas.Select(i => new Application.CatalogClient.CreateProductData()
            {
                Name = i.Name,
                Description = i.Description,
                Price = i.Price
            }).ToArray();

            var request = new CreateProductsRequest();
            request.Datas.AddRange(productDatas);

            var result = await catalogClient.CreateProductsAsync(request);

            return Ok(result.Ids.ToArray());
        });
    }

    [HttpPut("products")]
    public async Task<IActionResult> UpdateProducts([FromBody] UpdateProductData[] datas)
    {
        return await this.HandleErrors(logger,async () =>
        {
            var productDatas = datas.Select(i => new Application.CatalogClient.UpdateProductData()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price
            }).ToArray();

            var request = new UpdateProductsRequest();
            request.Datas.AddRange(productDatas);

            var result = await catalogClient.UpdateProductsAsync(request);

            return Ok();
        });
    }

    [HttpDelete("products")]
    public async Task<IActionResult> RemoveProducts([FromBody] int[] productIds)
    {
        return await this.HandleErrors(logger, async () =>
        {
            var request = new RemoveProductsRequest();
            request.Ids.AddRange(productIds);

            var result = await catalogClient.RemoveProductsAsync(request);
            return Ok();
        });
    }
    

}
