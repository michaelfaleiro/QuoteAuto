using QuoteAuto.Communication.Response.QuoteProducts;
using QuoteAuto.Communication.Response.Quotes;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Communication.Response.SupplierPrices;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.GetById;

public class GetQuoteByIdUseCase(IQuoteRepository quoteRepository)
{
    public async Task<ResponseJson<QuoteWithProductsJsonResponse>> ExecuteAsync(string Id)
    {
        var quote = await quoteRepository.GetByIdAsync(Id) 
            ?? throw new KeyNotFoundException("Quote not found");

        var quoteProducts = quote.Products.Select(qp => new QuoteProductWithSupplierPriceJsonResponse(
            qp.Id,
            qp.ProductName,
            qp.SupplierPrices.Select(sp => new SupplierPriceJsonResponse(
                    sp.Id,
                    sp.SupplierName,
                    sp.Price,
                    sp.Brand,
                    sp.IsSelected
                )
            ).ToList()
            )).ToList();
        
        var data = new QuoteWithProductsJsonResponse(
            quote.Id,
            quote.Status,
            quoteProducts,
            quote.CreatedAt,
            quote.UpdatedAt
            );
        
        return new ResponseJson<QuoteWithProductsJsonResponse>(data);
    }
}