using SmallShopWeb.Catalog.App.Entities;

namespace SmallShopWeb.Catalog.App.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task AddAsync(Product product);

        Task AddRangeAsync(IEnumerable<Product> products);

        Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids);

        Task<IEnumerable<int>> CheckProductsExistAsync(IEnumerable<int> ids);

        Task BatchRemoveAsync(IEnumerable<int> ids);

    }
}
