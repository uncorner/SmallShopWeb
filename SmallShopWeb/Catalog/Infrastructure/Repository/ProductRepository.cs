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

        public void Add(Product product)
        {
            dbContext.Products.Add(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await dbContext.Products.ToArrayAsync();

        public async Task<IEnumerable<Product>> GetByIds(IEnumerable<int> ids)
        {
            return await dbContext.Products.Where(i => ids.Contains(i.Id)).ToArrayAsync()
                ?? Array.Empty<Product>();
        }
    }
}
