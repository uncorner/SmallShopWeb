using Microsoft.EntityFrameworkCore;
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

        public Task AddAsync(Product product)
        {
            return dbContext.Products.AddAsync(product).AsTask();
        }

        public Task AddRangeAsync(IEnumerable<Product> products)
        {
            return dbContext.Products.AddRangeAsync(products);
        }

        public Task<Product[]> GetAllAsync() =>
            dbContext.Products.OrderBy(i => i.Id).ToArrayAsync();
            //.ToArrayAsync();

        public Task<Product[]> GetByIdsAsync(IEnumerable<int> ids)
        {
            return dbContext.Products.Where(i => ids.Contains(i.Id)).ToArrayAsync();
                //?? Array.Empty<Product>();
        }

        public Task<int[]> CheckProductsExistAsync(IEnumerable<int> ids)
        {
            return dbContext.Products.Where(i => ids.Contains(i.Id))
                .Select(i => i.Id).ToArrayAsync();
        }

        public Task BatchRemoveAsync(IEnumerable<int> ids)
        {
            return dbContext.Products.Where(i => ids.Contains(i.Id)).ExecuteDeleteAsync();
        }

    }
}
