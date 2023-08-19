using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopAPI.Infrastructure.Client;
using SmallShopWeb.ShopCommon.Dto;
using Google.Protobuf.WellKnownTypes;
using System.Net;

namespace SmallShopWeb.ShopAPI.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly ProductCatalog.ProductCatalogClient catalogClient;
        private readonly ILogger<GatewayController> logger;

        public GatewayController(ProductCatalog.ProductCatalogClient catalogClient, ILogger<GatewayController> logger)
        {
            this.catalogClient = catalogClient;
            this.logger = logger;
        }

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            return Ok("API info");
        }

        [HttpGet("product/list")]
        public async Task<IActionResult> GetProducts()
        {
            try {
                var listReply = await catalogClient.GetProductsAsync(new Empty());

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

    }
}
