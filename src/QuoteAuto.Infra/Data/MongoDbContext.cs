using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace QuoteAuto.Infra.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDB:ConnectionString"];
        var databaseName = configuration["MongoDB:DatabaseName"];

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("MongoDB connection string is not configured");

        if (string.IsNullOrEmpty(databaseName))
            throw new InvalidOperationException("MongoDB database name is not configured");

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoDatabase GetDatabase() => _database;
}