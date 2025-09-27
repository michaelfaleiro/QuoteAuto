using QuoteAuto.Communication.Response.QuoteProducts;
using QuoteAuto.Communication.Response.Vehicles;

namespace QuoteAuto.Communication.Response.Quotes;

public record QuoteWithProductsJsonResponse(
    string Id,
    VehicleJsonResponse Vehicle,
    string Status,
    IEnumerable<QuoteProductWithSupplierPriceJsonResponse> Products,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );