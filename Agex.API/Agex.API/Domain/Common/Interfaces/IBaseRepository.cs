namespace Agex.API.Infrastructure.Common.Repository;

public interface IBaseRepository<TEntity, in TKey>
{
    Task<TEntity?> GetAsync(TKey id);
    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}