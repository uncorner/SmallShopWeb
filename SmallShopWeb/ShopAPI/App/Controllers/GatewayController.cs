using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopAPI.Protos;
using SmallShopWeb.ShopCommon.Dto;
using Google.Protobuf.WellKnownTypes;

namespace SmallShopWeb.ShopAPI.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly ProductCatalog.ProductCatalogClient catalogClient;

        public GatewayController(ProductCatalog.ProductCatalogClient catalogClient)
        {
            this.catalogClient = catalogClient;
        }

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            return Ok("API info");
        }

        //[HttpGet("product/list")]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var result = await catalogClient.GetProductsAsync();
        //    if (result is null)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }

        //    return Ok(result);
        //}

        [HttpGet("product/list")]
        public async Task<IActionResult> GetProducts()
        {
            //TODO: use try catch
            var listReply = await catalogClient.GetProductsAsync(new Empty());

            var productInfos = listReply.Products.Select(p =>
                new ProductInfo(p.Id, p.Name, p.Description, p.Price)).ToArray();

            return Ok(productInfos);
        }

    }
}
