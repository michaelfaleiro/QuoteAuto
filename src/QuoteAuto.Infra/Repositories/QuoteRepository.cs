using QuoteAuto.Core.Entities;
using QuoteAuto.Core.Repositories;
using QuoteAuto.Infra.Data;

namespace QuoteAuto.Infra.Repositories;

public class QuoteRepository(MongoDbContext context) : RepositoryBase<Quote>(context.GetDatabase(), "Quotes"), 
    IQuoteRepository
{
    
}