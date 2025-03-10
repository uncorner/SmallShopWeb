﻿using Google.Protobuf.WellKnownTypes;

namespace SmallShopWeb.ShopAPI.Application.CatalogClient;

public interface IProductCatalogClient
{
    Task<ProductListReply> GetProductsAsync();
    Task<CreateProductsReply> CreateProductsAsync(CreateProductsRequest request);
    Task<Empty> UpdateProductsAsync(UpdateProductsRequest request);
    Task<Empty> RemoveProductsAsync(RemoveProductsRequest request);

}
