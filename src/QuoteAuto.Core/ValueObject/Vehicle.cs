namespace QuoteAuto.Core.ValueObject;

public class Vehicle : ValueObject
{
    public string Model { get; private set; }
    public string Plate { get; private set; }
    public string Vin { get; private set; }
    public int Year { get; private set; }
    
    public Vehicle(string model, string plate, string vin, int year)
    {
        Model = model;
        Plate = plate;
        Vin = vin;
        Year = year;
    }
    
    public void UpdateVehicle(Vehicle vehicle)
    {
        Model = vehicle.Model;
        Plate = vehicle.Plate;
        Vin = vehicle.Vin;
        Year = vehicle.Year;
    }
}