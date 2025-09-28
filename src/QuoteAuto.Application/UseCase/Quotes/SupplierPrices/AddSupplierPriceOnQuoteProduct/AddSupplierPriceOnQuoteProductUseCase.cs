using QuoteAuto.Communication.Request.Quotes;
using QuoteAuto.Core.Entities;
using QuoteAuto.Core.Repositories;

namespace QuoteAuto.Application.UseCase.Quotes.SupplierPrices.AddSupplierPriceOnQuoteProduct;

public class AddSupplierPriceOnQuoteProductUseCase(IQuoteRepository quoteRepository)
{
    public async Task ExecuteAsync(string quoteId, string quoteProductId, AddSupplierPriceOnQuoteProductRequest request)
    {
        var quote = await quoteRepository.GetByIdAsync(quoteId)
            ?? throw new KeyNotFoundException("Quote not found");
        
        var quoteProduct = quote.Products
            .FirstOrDefault(qp => qp.Id == quoteProductId)
            ?? throw new KeyNotFoundException("Quote product not found in quote");

        var supplierPrice = new SupplierPrice(
            request.SupplierName,
            request.Price,
            request.Brand,
            request.Sku
            );
        
        quoteProduct.AddSupplierPrice(supplierPrice);
        
        var updatedQuote = await quoteRepository.UpdateAsync(quoteId, quote)
            ?? throw new Exception("Error adding supplier price to quote product");
    }
}