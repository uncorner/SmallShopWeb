using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace SmallShopWeb.Catalog.Presentation.GrpcService
{
    public class ProductCatalogGrpcService : ProductCatalog.ProductCatalogBase
    {
        private readonly IProductCatalogService service;

        public ProductCatalogGrpcService(IProductCatalogService service)
        {
            this.service = service;
        }

        public override Task<ProductListReply> GetProducts(Empty request, ServerCallContext context) =>
            service.GetProducts(context);

        public override Task<CreateProductsReply> CreateProducts(CreateProductsRequest request, ServerCallContext context) =>
            service.CreateProducts(request, context);

        public override Task<Empty> UpdateProducts(UpdateProductsRequest request, ServerCallContext context) =>
            service.UpdateProducts(request, context);

        public override Task<Empty> RemoveProducts(RemoveProductsRequest request, ServerCallContext context) =>
            service.RemoveProducts(request, context);

    }
}
