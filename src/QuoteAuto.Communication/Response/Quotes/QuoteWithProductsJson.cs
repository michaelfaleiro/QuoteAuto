using QuoteAuto.Communication.Response.QuoteProducts;

namespace QuoteAuto.Communication.Response.Quotes;

public record QuoteWithProductsJson(
    string Id,
    string Status,
    IEnumerable<QuoteProductJsonResponse> Products,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );