using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopCommon.Dto;
using System.Net;
using SmallShopWeb.ShopAPI.App.Client;
using CreateProductData = SmallShopWeb.Catalog.App.Dto.CreateProductData;

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

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            return Ok("API info");
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            try {
                var listReply = await catalogClient.GetProductsAsync();

                var productInfos = listReply.Products.Select(p =>
                    new ProductInfo(p.Id, p.Name, p.Description, p.Price)).ToArray();

                return Ok(productInfos);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductData[] datas)
        {
            try
            {
                var productDatas = datas.Select(i => new Client.CreateProductData()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price
                }).ToArray();

                var request = new CreateProductsRequest();
                request.Datas.AddRange(productDatas);

                var result = await catalogClient.CreateProducts(request);

                return Ok(result.Ids.ToArray());
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

    }
}
