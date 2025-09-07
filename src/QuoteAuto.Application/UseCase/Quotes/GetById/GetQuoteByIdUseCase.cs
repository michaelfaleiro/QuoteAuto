using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.GetById;

public class GetQuoteByIdUseCase(IQuoteRepository quoteRepository)
{
    public async Task<ResponseJson<QuoteJsonResponse>> ExecuteAsync(string Id)
    {
        var quote = await quoteRepository.GetByIdAsync(Id) 
            ?? throw new KeyNotFoundException("Quote not found");

        var data = new QuoteJsonResponse(
            quote.Id,
            quote.Status,
            quote.CreatedAt,
            quote.UpdatedAt
            );
        
        return new ResponseJson<QuoteJsonResponse>(data);
    }
    
}