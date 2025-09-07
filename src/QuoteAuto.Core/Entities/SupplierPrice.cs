namespace QuoteAuto.Core.Entities;

public class SupplierPrice : BaseEntity
{
    public string SupplierName { get; private set; }
    public decimal Price { get; private set; }
    public string Brand { get; private set; }
    public bool IsSelected { get; private set; }

    public SupplierPrice(string supplierName, decimal price, string brand)
    {
        SupplierName = supplierName;
        Price = price;
        Brand = brand;
        IsSelected = false;
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