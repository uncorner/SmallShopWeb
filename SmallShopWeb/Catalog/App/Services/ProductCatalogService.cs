using Grpc.Core;
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

        public Task<ProductListReply> GetProducts(ServerCallContext context)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();
            // TODO async
            var products = productRepository.GetAllAsync().Result;

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

            return Task.FromResult(listReply);
        }
    }
}
