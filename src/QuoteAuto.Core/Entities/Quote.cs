namespace QuoteAuto.Core.Entities;

public class Quote : BaseEntity
{
    public string Status { get; private set; }
    public IList<QuoteProduct> Products { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    public Quote( string status)
    {
        Status = status;
        Products = [];
        CreatedAt = DateTime.UtcNow;
    }
    
    public void UpdateQuote(string status)
    {
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