using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmallShopWeb.Catalog.App.Services;

namespace SmallShopWeb.Catalog.Infrastructure.Services
{
    public class ProductCatalogGrpcService : ProductCatalog.ProductCatalogBase
    {
        private readonly IProductCatalogService service;

        public ProductCatalogGrpcService(IProductCatalogService service)
        {
            this.service = service;
        }

        public override Task<ProductListReply> GetProducts(Empty request, ServerCallContext context)
        {
            return service.GetProducts(context);
        }

        public override Task<CreateProductsReply> CreateProducts(CreateProductsRequest request, ServerCallContext context)
        {
            return service.CreateProducts(request, context);
        }

        public override Task<Empty> UpdateProducts(UpdateProductsRequest request, ServerCallContext context)
        {
            return service.UpdateProducts(request, context);
        }

        public override Task<Empty> RemoveProducts(RemoveProductsRequest request, ServerCallContext context)
        {
            return service.RemoveProducts(request, context);
        }

    }
}
