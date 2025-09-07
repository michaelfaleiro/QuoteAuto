using QuoteAuto.Communication.Response.QuoteProducts;
using QuoteAuto.Communication.Response.SupplierPrices;

namespace QuoteAuto.Communication.Response.Quotes;

public record QuoteJsonResponse(
    string Id,
    string Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt);