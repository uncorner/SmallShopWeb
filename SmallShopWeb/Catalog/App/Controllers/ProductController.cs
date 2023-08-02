﻿using Microsoft.AspNetCore.Mvc;
using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.ShopCommon.App;

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
            //return new[] {
            //    new Product("Майка", "Майка с надписью", 10),
            //    new Product("Чехол для телефона", "Чехол Samsung Galaxy s22", 15)};

            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var products = await productRepository.GetAllAsync();

            var result = products.Select(p =>
                new Product(p.Name, p.Description ?? "", p.Price)).ToArray();

            return Ok(result);
        }

    }
}
