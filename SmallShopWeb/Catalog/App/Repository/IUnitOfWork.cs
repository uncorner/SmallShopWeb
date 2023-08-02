namespace SmallShopWeb.Catalog.App.Repository
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IProductRepository CreateProductRepository();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
