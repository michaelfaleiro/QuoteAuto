namespace QuoteAuto.Communication.Response.SupplierPrices;

public record SupplierPriceJsonResponse(
    string Id,
    string SupplierName,
    decimal Price,
    string Brand,   
    bool IsSelected
    );