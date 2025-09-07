using QuoteAuto.Communication.Request.Quotes;
using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Core.Entities;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.Register;

public class RegisterQuoteUseCase(IQuoteRepository quoteRepository)
{
    public async Task<ResponseJson<QuoteJsonResponse>> ExecuteAsync(RegisterQuoteRequest request)
    {
        var quote = new Quote(
            request.Status);
        
        var result = await quoteRepository.AddAsync(quote);
        var data = new QuoteJsonResponse
        (
            result.Id,
            result.Status,
            result.CreatedAt,
            result.UpdatedAt
        );
        
        return new ResponseJson<QuoteJsonResponse>(data);
    }
}