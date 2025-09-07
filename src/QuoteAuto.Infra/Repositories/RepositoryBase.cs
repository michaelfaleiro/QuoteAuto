using MongoDB.Driver;
using QuoteAuto.Core.Repositories;
using QuoteAuto.Core.Shared.Response;

namespace QuoteAuto.Infra.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly IMongoCollection<TEntity> Collection;
    protected readonly IMongoDatabase Database;
    
    protected RepositoryBase(IMongoDatabase database, string collectionName)
    {
        Database = database ?? throw new ArgumentNullException(nameof(database));
        Collection = Database.GetCollection<TEntity>(collectionName);
    }
    
    public async Task<PagedResponse<TEntity>> GetAllAsync(int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;
        var totalCount = await Collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);

        var items = await Collection.Find(FilterDefinition<TEntity>.Empty)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();

        return new PagedResponse<TEntity>
        (
            pageNumber,
            pageSize,
            (int)totalCount,
            items
        );
    }

    public async Task<TEntity?> GetByIdAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        return await Collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await Collection.InsertOneAsync(entity);
        return entity;
        
    }

    public async Task<TEntity?> UpdateAsync(string id, TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        if (await Collection.Find(filter).FirstOrDefaultAsync() == null)
            return null;
        await Collection.ReplaceOneAsync(filter, entity);
        return entity;
    }
}