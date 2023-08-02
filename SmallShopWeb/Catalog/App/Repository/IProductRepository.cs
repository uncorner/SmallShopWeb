using SmallShopWeb.Catalog.App.Entities;

namespace SmallShopWeb.Catalog.App.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        void Add(Product product);

    }
}
