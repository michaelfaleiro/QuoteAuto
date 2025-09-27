using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Communication.Response.Vehicles;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.GetAll;

public class GetAllQuotesUseCase(IQuoteRepository quoteRepository)
{
    public async Task<PagedResponseJson<QuoteJsonResponse>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var quotes = await quoteRepository.GetAllAsync(pageNumber, pageSize);
        
        var data = quotes.Data.Select(quote => new QuoteJsonResponse(
            quote.Id,
            new VehicleJsonResponse(
                quote.Vehicle.Model,
                quote.Vehicle.Plate,
                quote.Vehicle.Vin,
                quote.Vehicle.Year
            ),
            quote.Status,
            quote.CreatedAt,
            quote.UpdatedAt
            ));
        
        return new PagedResponseJson<QuoteJsonResponse>(pageNumber, pageSize, quotes.TotalCount, data);
    }
    
}