using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.App.Controllers
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

        [HttpGet("product/list")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await catalogClient.GetProductsAsync();
        }

    }
}
