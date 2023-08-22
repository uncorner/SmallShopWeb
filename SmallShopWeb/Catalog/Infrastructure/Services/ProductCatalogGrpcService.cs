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

        public override async Task<ProductListReply> GetProducts(Empty request, ServerCallContext context)
        {
            return await service.GetProducts(context);
        }

        public override async Task<CreateProductsReply> CreateProducts(CreateProductsRequest request, ServerCallContext context)
        {
            return await service.CreateProducts(request, context);
        }

        public override async Task<Empty> UpdateProducts(UpdateProductsRequest request, ServerCallContext context)
        {
            return await service.UpdateProducts(request, context);
        }

        public override async Task<Empty> RemoveProducts(RemoveProductsRequest request, ServerCallContext context)
        {
            return await service.RemoveProducts(request, context);
        }

    }
}
