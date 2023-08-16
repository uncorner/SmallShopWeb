using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmallShopWeb.Catalog.App.Repository;
using SmallShopWeb.Catalog.Protos;

namespace SmallShopWeb.Catalog.Services
{
    public class ProductCatalogService : ProductCatalog.ProductCatalogBase
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ProductCatalogService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory= unitOfWorkFactory;
        }

        // TODO: async
        public override Task<ProductListReply> GetProducts(Empty request, ServerCallContext context)
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var productRepository = unitOfWork.CreateProductRepository();
            // TODO
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
