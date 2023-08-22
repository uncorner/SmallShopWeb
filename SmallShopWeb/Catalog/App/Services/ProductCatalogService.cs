using Grpc.Core;
using SmallShopWeb.Catalog.App.Entities;
using SmallShopWeb.Catalog.App.Repository;

namespace SmallShopWeb.Catalog.App.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ProductCatalogService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<ProductListReply> GetProducts(ServerCallContext context)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var products = await productRepository.GetAllAsync();

            var productReplyList = products.Select(p =>
                new ProductReply()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price
                }).ToArray();

            ProductListReply listReply = new();
            listReply.Products.AddRange(productReplyList);

            return listReply;
        }

        public async Task<CreateProductsReply> CreateProducts(CreateProductsRequest request, ServerCallContext context)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();

            var products = request.Datas.Select(i => new Product(i.Name)
            {
                Description = i.Description,
                Price = i.Price
            }).ToArray();

            await productRepository.AddRangeAsync(products);
            await unitOfWork.SaveChangesAsync();

            var ids = products.Select(i => i.Id).ToArray();
            
            var result = new CreateProductsReply();
            result.Ids.AddRange(ids);
            return result;
        }

        //        [HttpPost("products")]
        //        public async Task<IActionResult> CreateProducts([FromBody] CreateProductData[] datas)
        //        {
        //            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
        //            var productRepository = unitOfWork.CreateProductRepository();

        //            var products = datas.Select(i => new Product(i.Name)
        //            {
        //                Description = i.Description,
        //                Price = i.Price
        //            }).ToArray();

        //            await productRepository.AddRange(products);
        //            await unitOfWork.SaveChangesAsync();

        //            var ids = products.Select(i => i.Id).ToArray();
        //            return Ok(ids);
        //        }


    }
}
