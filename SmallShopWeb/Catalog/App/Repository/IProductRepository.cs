using SmallShopWeb.Catalog.App.Entities;

namespace SmallShopWeb.Catalog.App.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task Add(Product product);

        Task AddRange(IEnumerable<Product> products);

        Task<IEnumerable<Product>> GetByIds(IEnumerable<int> ids);

    }
}
