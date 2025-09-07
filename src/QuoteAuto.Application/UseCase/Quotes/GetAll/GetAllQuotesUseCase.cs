using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.GetAll;

public class GetAllQuotesUseCase(IQuoteRepository quoteRepository)
{
    public async Task<PagedResponseJson<QuoteJsonResponse>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var quotes = await quoteRepository.GetAllAsync(pageNumber, pageSize);
        
        var data = quotes.Data.Select(quote => new QuoteJsonResponse(
            quote.Id,
            quote.Status,
            quote.CreatedAt,
            quote.UpdatedAt
            ));
        
        return new PagedResponseJson<QuoteJsonResponse>(pageNumber, pageSize, quotes.TotalCount, data);
    }
    
}