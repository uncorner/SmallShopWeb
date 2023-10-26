using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopCommon.Dto;
using SmallShopWeb.ShopAPI.App.Client;
using CreateProductData = SmallShopWeb.Catalog.App.Dto.CreateProductData;
using UpdateProductData = SmallShopWeb.Catalog.App.Dto.UpdateProductData;

namespace SmallShopWeb.ShopAPI.App.Controllers
{
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
        public Task<IActionResult> GetProducts()
        {
            return this.HandleErrors(logger, async () =>
            {
                var listReply = await catalogClient.GetProductsAsync();

                var productInfos = listReply.Products.Select(p =>
                    new ProductInfo(p.Id, p.Name, p.Description, p.Price)).ToArray();

                return Ok(productInfos);
            });
        }
        
        [HttpPost("products")]
        public Task<IActionResult> CreateProducts([FromBody] CreateProductData[] datas)
        {
            return this.HandleErrors(logger, async () =>
            {
                var productDatas = datas.Select(i => new Client.CreateProductData()
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
        public Task<IActionResult> UpdateProducts([FromBody] UpdateProductData[] datas)
        {
            return this.HandleErrors(logger,async () =>
            {
                var productDatas = datas.Select(i => new Client.UpdateProductData()
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
        public Task<IActionResult> RemoveProducts([FromBody] int[] productIds)
        {
            return this.HandleErrors(logger, async () =>
            {
                var request = new RemoveProductsRequest();
                request.Ids.AddRange(productIds);

                var result = await catalogClient.RemoveProductsAsync(request);
                return Ok();
            });
        }

    }
}
