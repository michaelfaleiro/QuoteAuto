using QuoteAuto.Communication.Response.QuoteProducts;

namespace QuoteAuto.Communication.Response.Quotes;

public record QuoteWithProductsJsonResponse(
    string Id,
    string Status,
    IEnumerable<QuoteProductWithSupplierPriceJsonResponse> Products,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );