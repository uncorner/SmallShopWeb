using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.ShopCommon.Dto;
using System.Net;
using SmallShopWeb.ShopAPI.App.Client;
using CreateProductData = SmallShopWeb.Catalog.App.Dto.CreateProductData;
using UpdateProductData = SmallShopWeb.Catalog.App.Dto.UpdateProductData;
using Grpc.Core;

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

                var result = await catalogClient.CreateProductsAsync(request);

                return Ok(result.Ids.ToArray());
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProducts([FromBody] UpdateProductData[] datas)
        {
            try
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
            }
            catch(RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.NotFound)
            {
                logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.NotFound, ex.Status.Detail);
            }
            catch(Exception ex)
            {
                logger.LogCritical(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [HttpDelete("products")]
        public async Task<IActionResult> RemoveProducts([FromBody] int[] productIds)
        {
            try
            {
                var request = new RemoveProductsRequest();
                request.Ids.AddRange(productIds);

                var result = await catalogClient.RemoveProductsAsync(request);
                return Ok();
            }
            catch (RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.NotFound)
            {
                logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.NotFound, ex.Status.Detail);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }


    }
}
