namespace SmallShopWeb.Catalog.Application.Repository
{
    public interface IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork();
    }
}
