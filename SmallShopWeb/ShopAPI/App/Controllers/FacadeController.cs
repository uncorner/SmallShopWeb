using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class FacadeController : ControllerBase
    {

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            return Ok("API info");
        }

    }
}
