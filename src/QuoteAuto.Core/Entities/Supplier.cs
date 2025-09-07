namespace QuoteAuto.Core.Entities;

public class Supplier : BaseEntity
{
    public string SupplierName { get; private set; }

    public Supplier(string supplierName)
    {
        SupplierName = supplierName;
    }

}