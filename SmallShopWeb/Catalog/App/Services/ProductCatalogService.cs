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

            return await Task.FromResult(listReply);
        }
    }
}
