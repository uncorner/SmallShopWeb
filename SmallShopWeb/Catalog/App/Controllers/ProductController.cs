using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.Catalog.App.Dto;
using SmallShopWeb.Catalog.App.Entities;
using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.Catalog.App.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ProductController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var products = await productRepository.GetAllAsync();

            var result = products.Select(p =>
                new ProductInfo(p.Id, p.Name, p.Description ?? "", p.Price)).ToArray();

            return Ok(result);
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductData data)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var product = new Product(data.Name)
            {
                Description = data.Description,
                Price = data.Price
            };

            productRepository.Add(product);
            await unitOfWork.SaveChangesAsync();

            return Ok(product.Id);
        }

    }
}
