using MongoDB.Bson.Serialization.Attributes;
using QuoteAuto.Core.ValueObject;

namespace QuoteAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class Quote : BaseEntity
{
    public Vehicle Vehicle { get; private set; }
    public string Status { get; private set; }
    public IList<QuoteProduct> Products { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    public Quote(string status, Vehicle vehicle)
    {
        Status = status;
        Vehicle = vehicle;
        Products = [];
        CreatedAt = DateTime.UtcNow;
    }
    public void UpdateQuote(string status, Vehicle vehicle)
    {
        Vehicle.UpdateVehicle(
            vehicle.Model,
            vehicle.Plate,
            vehicle.Vin,
            vehicle.Year
        );
        Status = status;
        Update();
    }
    
    public void AddProduct(QuoteProduct quoteProduct)
    {
        Products.Add(quoteProduct);
        Update();
    }
    
    public void RemoveProduct(QuoteProduct quoteProduct)
    {
        Products.Remove(quoteProduct);
        Update();
    }
    
    void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}