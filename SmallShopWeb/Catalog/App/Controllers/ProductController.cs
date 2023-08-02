using Microsoft.AspNetCore.Mvc;
using ShopCommon.App;

namespace Catalog.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return new[] {
                new Product("Майка", "Майка с надписью", 10),
                new Product("Чехол для телефона", "Чехол Samsung Galaxy s22", 15)};
        }

    }
}
