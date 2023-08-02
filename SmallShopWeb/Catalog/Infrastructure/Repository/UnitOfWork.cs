using SmallShopWeb.Catalog.App.Repository;

namespace SmallShopWeb.Catalog.Infrastructure.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IProductRepository CreateProductRepository() => 
            new ProductRepository(dbContext);

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        #region Disposable
        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }

        


        #endregion

    }
}
