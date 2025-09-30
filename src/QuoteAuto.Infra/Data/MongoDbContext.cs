using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace QuoteAuto.Infra.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient client, IConfiguration configuration)
    {
        var databaseName = configuration["MongoSettings:DatabaseName"];

        if (string.IsNullOrEmpty(databaseName))
            throw new InvalidOperationException("MongoDB database name is not configured");

        _database = client.GetDatabase(databaseName);
    }

    public IMongoDatabase GetDatabase() => _database;
}