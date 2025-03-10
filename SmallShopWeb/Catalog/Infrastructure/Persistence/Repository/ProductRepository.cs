﻿using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.Application.Repository;
using SmallShopWeb.Catalog.Domain.Entities;

namespace SmallShopWeb.Catalog.Infrastructure.Persistence.Repository;

internal class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
    }

    public async Task AddRangeAsync(IEnumerable<Product> products)
    {
        await dbContext.AddRangeAsync(products);
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await dbContext.Products.OrderBy(i => i.Id).ToArrayAsync();

    public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await dbContext.Products.Where(i => ids.Contains(i.Id)).ToArrayAsync()
            ?? Array.Empty<Product>();
    }

    public async Task<IEnumerable<int>> CheckProductsExistAsync(IEnumerable<int> ids)
    {
        return await dbContext.Products.Where(i => ids.Contains(i.Id))
            .Select(i => i.Id).ToArrayAsync();
    }

    public async Task BatchRemoveAsync(IEnumerable<int> ids)
    {
        await dbContext.Products.Where(i => ids.Contains(i.Id)).ExecuteDeleteAsync();
    }

}
