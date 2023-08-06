﻿using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopAPI.App.Network;
using System.Net;

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

        [HttpGet("product/list")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await catalogClient.GetProductsAsync();
            if (result is null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok(result);
        }

    }
}
