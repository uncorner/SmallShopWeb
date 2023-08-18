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

    }
}
