using QuoteAuto.Core.Repositories;
using QuoteAuto.Infra.Data;
using QuoteAuto.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace QuoteAuto.Infra;

public static class DependecyInjection
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped<MongoDbContext>();
        
        services.AddScoped<IQuoteRepository, QuoteRepository>();
    }
}