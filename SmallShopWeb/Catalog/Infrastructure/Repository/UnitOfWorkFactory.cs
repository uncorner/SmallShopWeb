using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.App.Repository;

namespace SmallShopWeb.Catalog.Infrastructure.Repository
{
    class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public UnitOfWorkFactory(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork CreateUnitOfWork() => new UnitOfWork(dbContextFactory.CreateDbContext());

    }
}
