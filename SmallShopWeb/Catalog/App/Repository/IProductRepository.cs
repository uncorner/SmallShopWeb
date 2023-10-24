using SmallShopWeb.Catalog.App.Entities;

namespace SmallShopWeb.Catalog.App.Repository
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllAsync();

        Task AddAsync(Product product);

        Task AddRangeAsync(IEnumerable<Product> products);

        Task<Product[]> GetByIdsAsync(IEnumerable<int> ids);

        Task<int[]> CheckProductsExistAsync(IEnumerable<int> ids);

        Task BatchRemoveAsync(IEnumerable<int> ids);

    }
}
