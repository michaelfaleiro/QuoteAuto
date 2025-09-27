using QuoteAuto.Communication.Request.Quotes;
using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Communication.Response.Vehicles;
using QuoteAuto.Core.Entities;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.Register;

public class RegisterQuoteUseCase(IQuoteRepository quoteRepository)
{
    public async Task<ResponseJson<QuoteJsonResponse>> ExecuteAsync(RegisterQuoteRequest request)
    {
        var quote = new Quote(
            request.Status,
            request.Vehicle
            );
        
        var result = await quoteRepository.AddAsync(quote);
        var data = new QuoteJsonResponse
        (
            result.Id,
            new VehicleJsonResponse(
                result.Vehicle.Model,
                result.Vehicle.Plate,
                result.Vehicle.Vin,
                result.Vehicle.Year
            ),
            result.Status,
            result.CreatedAt,
            result.UpdatedAt
        );
        
        return new ResponseJson<QuoteJsonResponse>(data);
    }
}