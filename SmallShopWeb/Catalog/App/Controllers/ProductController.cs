using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.Catalog.App.Dto;
using SmallShopWeb.Catalog.App.Entities;
using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.ShopCommon.Dto;
using System.Collections.Immutable;
using System.Net;

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
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductData[] datas)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var products = datas.Select(i => new Product(i.Name)
            {
                Description = i.Description,
                Price = i.Price
            }).ToArray();

            await productRepository.AddRange(products);
            await unitOfWork.SaveChangesAsync();

            var ids = products.Select(i => i.Id).ToArray();
            return Ok(ids);
        }

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProducts([FromBody] UpdateProductData[] datas)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var ids = datas.Select(i => i.Id).ToArray();
            var products = await productRepository.GetByIds(ids);
            var productsMap = products.ToDictionary(i => i.Id);

            foreach (var data in datas)
            {
                if (productsMap.TryGetValue(data.Id, out Product? product))
                {
                    product.Name = data.Name;
                    product.Description = data.Description;
                    product.Price = data.Price;
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound,
                        $"Product with id {data.Id} is not found");
                }
            }

            await unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("products")]
        public async Task<IActionResult> RemoveProducts([FromBody] int[] productIds)
        {
            productIds = productIds.Distinct().ToArray();

            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();
            var existedIds = await productRepository.CheckProductsExist(productIds);

            if (productIds.Length != existedIds.Count())
            {
                foreach(var id in productIds) {
                    if (!existedIds.Contains(id))
                    {
                        return StatusCode((int)HttpStatusCode.NotFound,
                            $"Product with id {id} is not found");
                    }
                }
            }

            await productRepository.BatchRemove(productIds);
            return Ok();
        }

    }
}
