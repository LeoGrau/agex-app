using Agex.API.Domain.Common.Interfaces;
using Agex.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Agex.API.Infrastructure.Common.Repository;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    public async Task BeginTransactionAsync()
    {
        _transaction = await appDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await appDbContext.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await _transaction.RollbackAsync();
            throw;
        }
        finally
        {
            await appDbContext.DisposeAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }
}