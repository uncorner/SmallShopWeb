using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.Application.Repository;

namespace SmallShopWeb.Catalog.Infrastructure.Persistence.Repository
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
