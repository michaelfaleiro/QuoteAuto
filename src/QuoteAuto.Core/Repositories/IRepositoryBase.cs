using QuoteAuto.Core.Shared.Response;

namespace QuoteAuto.Core.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<PagedResponse<TEntity>> GetAllAsync(int pageNumber, int pageSize);
    Task<TEntity?> GetByIdAsync(string id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(string id, TEntity entity);
}