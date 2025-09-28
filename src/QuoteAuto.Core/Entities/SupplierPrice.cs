using MongoDB.Bson.Serialization.Attributes;

namespace QuoteAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class SupplierPrice : BaseEntity
{
    public string SupplierName { get; private set; }
    public decimal Price { get; private set; }
    public string Brand { get; private set; }
    public string Sku { get; private set; }
    public bool IsSelected { get; private set; }
    
    public SupplierPrice(string supplierName, decimal price, string brand, string sku)
    {
        SupplierName = supplierName;
        Price = price;
        Brand = brand;
        Sku = sku;
        IsSelected = false;
    }

    public void UpdateSupplierPrice(string supplierName, decimal price, string brand, string sku)
    {
        SupplierName = supplierName;
        Price = price;
        Brand = brand;
        Sku = sku;
    }
    
    public void Select()
    {
        IsSelected = true;
    }

    public void Deselect()
    {
        IsSelected = false;
    }
}