﻿using SmallShopWeb.Catalog.Application.Repository;

namespace SmallShopWeb.Catalog.Infrastructure.Persistence.Repository;

sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #region Repositories

    public IProductRepository CreateProductRepository() => 
        new ProductRepository(dbContext);

    #endregion

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }

    #region IDisposable, IAsyncDisposable
    public void Dispose()
    {
        dbContext.Dispose();
    }
    
    public async ValueTask DisposeAsync()
    {
        await dbContext.DisposeAsync();
    }
    #endregion

}
