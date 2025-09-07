using QuoteAuto.Communication.Request.Quotes;
using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.Update;

public class UpdateQuoteUseCase(IQuoteRepository quoteRepository)
{
    public async Task<ResponseJson<QuoteJsonResponse>> ExecuteAsync(string id, UpdateQuoteRequest request)
    {
        var quote = await quoteRepository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException("Quote not found");
        
        quote.UpdateQuote(
            request.Status
            );
        
        var response = await quoteRepository.UpdateAsync(id, quote)
            ?? throw new Exception("Error updating quote");
        
        var data = new QuoteJsonResponse(
            response.Id,
            response.Status,
            response.CreatedAt,
            response.UpdatedAt
            );
        
        return new ResponseJson<QuoteJsonResponse>(data);
    }
    
}