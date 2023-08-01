namespace ShopAPI.App
{
    public interface ICatalogClient
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
    }
}