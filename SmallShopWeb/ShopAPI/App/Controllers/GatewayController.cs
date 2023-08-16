using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopAPI.App.Network;
using System.Net;
using SmallShopWeb.ShopAPI.Protos;
using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopAPI.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly ICatalogClient catalogClient;

        public GatewayController(ICatalogClient catalogClient)
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
            using var channel = GrpcChannel.ForAddress("https://localhost:7240");
            var client = new ProductCatalog.ProductCatalogClient(channel);
                        
            var listReply = await client.GetProductsAsync(new Google.Protobuf.WellKnownTypes.Empty());

            var productInfos = listReply.Products.Select(p =>
                new ProductInfo(p.Id, p.Name, p.Description, p.Price)).ToArray();

            return Ok(productInfos);
        }

    }
}
