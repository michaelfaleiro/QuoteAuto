namespace QuoteAuto.Core.Entities;

public class QuoteProduct : BaseEntity
{
    public string ProductName { get; private set; }
    public IList<SupplierPrice> SupplierPrices { get; private set; }

    public QuoteProduct(string productName)
    {
        ProductName = productName;
        SupplierPrices = [];
    }

    public void AddSupplierPrice(SupplierPrice supplierPrice)
    {
        SupplierPrices.Add(supplierPrice);
    }

    public void RemoveSupplierPrice(SupplierPrice supplierPrice)
    {
        SupplierPrices.Remove(supplierPrice);
    }

}