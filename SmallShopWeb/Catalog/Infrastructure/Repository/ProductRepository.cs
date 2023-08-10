﻿using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.App.Entities;
using SmallShopWeb.Catalog.App.Repository;

namespace SmallShopWeb.Catalog.Infrastructure.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            await dbContext.Products.AddAsync(product);
        }

        public async Task AddRange(IEnumerable<Product> products)
        {
            await dbContext.AddRangeAsync(products);
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await dbContext.Products.ToArrayAsync();

        public async Task<IEnumerable<Product>> GetByIds(IEnumerable<int> ids)
        {
            return await dbContext.Products.Where(i => ids.Contains(i.Id)).ToArrayAsync()
                ?? Array.Empty<Product>();
        }

        public async Task<IEnumerable<int>> CheckProductsExist(IEnumerable<int> productIds)
        {
            return await dbContext.Products.Where(i => productIds.Contains(i.Id))
                .Select(i => i.Id).ToArrayAsync();
        }

    }
}
