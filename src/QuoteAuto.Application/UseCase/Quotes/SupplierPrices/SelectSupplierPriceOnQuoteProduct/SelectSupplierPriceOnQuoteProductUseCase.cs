using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.SupplierPrices.SelectSupplierPriceOnQuoteProduct;

public class SelectSupplierPriceOnQuoteProductUseCase(IQuoteRepository quoteRepository)
{
    public async Task ExecuteAsync(string quoteId, string quoteProductId, string supplierPriceId)
    {
        var quote = await quoteRepository.GetByIdAsync(quoteId)
            ?? throw new KeyNotFoundException("Quote not found");

        var quoteProduct = quote.Products
            .FirstOrDefault(qp => qp.Id == quoteProductId)
            ?? throw new KeyNotFoundException("Quote product not found in quote");
        
        var supplierPrice = quoteProduct.SupplierPrices
            .FirstOrDefault(sp => sp.Id == supplierPriceId)
            ?? throw new KeyNotFoundException("Supplier price not found in quote product");

        supplierPrice.Select();

        var updatedQuote = await quoteRepository.UpdateAsync(quoteId, quote)
            ?? throw new Exception("Error selecting supplier price on quote product");
    }
    
}