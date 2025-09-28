namespace QuoteAuto.Communication.Response.SupplierPrices;

public record SupplierPriceJsonResponse(
    string Id,
    string SupplierName,
    decimal Price,
    string Brand, 
    string Sku,
    bool IsSelected
    );