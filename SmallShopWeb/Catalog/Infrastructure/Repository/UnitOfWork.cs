using SmallShopWeb.Catalog.App.Repository;

namespace SmallShopWeb.Catalog.Infrastructure.Repository
{
    sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Repositories

        public IProductRepository CreateProductRepository() => 
            new ProductRepository(dbContext);

        #endregion

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        #region IDisposable
        public void Dispose()
        {
            dbContext.Dispose();
        }
        #endregion

        #region IAsyncDisposable
        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }
        #endregion

    }
}
