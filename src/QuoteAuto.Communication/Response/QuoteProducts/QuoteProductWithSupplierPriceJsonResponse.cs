using QuoteAuto.Communication.Response.SupplierPrices;

namespace QuoteAuto.Communication.Response.QuoteProducts;

public record QuoteProductWithSupplierPriceJsonResponse(
    string Id,
    string ProductName,
    IEnumerable<SupplierPriceJsonResponse> SupplierPrices
    );