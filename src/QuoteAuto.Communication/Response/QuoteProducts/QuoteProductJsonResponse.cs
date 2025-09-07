using QuoteAuto.Communication.Response.SupplierPrices;

namespace QuoteAuto.Communication.Response.QuoteProducts;

public record QuoteProductJsonResponse(
    string Id,
    string ProductName
    );