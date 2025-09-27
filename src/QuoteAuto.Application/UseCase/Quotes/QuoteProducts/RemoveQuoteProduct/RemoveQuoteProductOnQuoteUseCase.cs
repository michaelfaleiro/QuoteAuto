using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.QuoteProducts.RemoveQuoteProduct;

public class RemoveQuoteProductOnQuoteUseCase(IQuoteRepository quoteRepository)
{
    public async Task ExecuteAsync(string quoteId, string quoteProductId)
    {
        var quote = await quoteRepository.GetByIdAsync(quoteId)
            ?? throw new KeyNotFoundException("Quote not found");

        var quoteProduct = quote.Products
            .FirstOrDefault(qp => qp.Id == quoteProductId)
            ?? throw new KeyNotFoundException("Quote product not found in quote");
        
        quote.RemoveProduct(quoteProduct);

        var updatedQuote = await quoteRepository.UpdateAsync(quoteId, quote)
            ?? throw new Exception("Error removing product from quote");
    }
    
}