namespace QuoteAuto.Communication.Response.Vehicles;

public record VehicleJsonResponse(
    string Model,
    string Plate,
    string Vin,
    int Year
    );