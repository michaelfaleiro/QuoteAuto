namespace QuoteAuto.Communication.Request.Quotes;

public record AddSupplierPriceOnQuoteProductRequest(
    string SupplierName,
    decimal Price,
    string Brand,
    string Sku
    );