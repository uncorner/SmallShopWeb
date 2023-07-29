using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class GatewayController : ControllerBase
    {

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            return Ok("API info");
        }

    }
}
