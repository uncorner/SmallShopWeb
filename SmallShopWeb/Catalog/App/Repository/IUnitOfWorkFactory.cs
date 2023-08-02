namespace SmallShopWeb.Catalog.App.Repository
{
    public interface IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork();
    }
}
