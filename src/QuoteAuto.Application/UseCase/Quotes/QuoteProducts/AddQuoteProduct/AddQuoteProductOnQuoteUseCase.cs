using QuoteAuto.Communication.Request.Quotes;
using QuoteAuto.Communication.Response.QuoteProducts;
using QuoteAuto.Communication.Response.Shared;
using QuoteAuto.Core.Entities;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.QuoteProducts.AddQuoteProduct;

public class AddQuoteProductOnQuoteUseCase(IQuoteRepository repository)
{
    public async Task ExecuteAsync(
        string quoteId,
        AddQuoteProductOnQuoteRequest request)
    {
        var quote = await repository.GetByIdAsync(quoteId)
            ?? throw new KeyNotFoundException("Quote not found");

        var quoteProduct = new QuoteProduct(
            request.ProductName
            );
        
        quote.AddProduct(quoteProduct);
        
        var updatedQuote = await repository.UpdateAsync(quoteId, quote)
            ?? throw new Exception("Error adding product to quote");
    }
}