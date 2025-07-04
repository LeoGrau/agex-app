using Agex.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Agex.API.Infrastructure.Common.Repository;

public class BaseRepository<TEntity, TKey>(AppDbContext appDbContext) : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly DbSet<TEntity> DbSet = appDbContext.Set<TEntity>();

    public virtual async Task<TEntity?> GetAsync(TKey id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }
}