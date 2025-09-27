using QuoteAuto.Communication.Response.QuoteProducts;
using QuoteAuto.Communication.Response.SupplierPrices;
using QuoteAuto.Communication.Response.Vehicles;

namespace QuoteAuto.Communication.Response.Quotes;

public record QuoteJsonResponse(
    string Id,
    VehicleJsonResponse Vehicle,
    string Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt);