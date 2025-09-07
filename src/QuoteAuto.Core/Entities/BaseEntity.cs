namespace QuoteAuto.Core.Entities;

public abstract class BaseEntity
{
    public string Id { get; private set; }

    protected BaseEntity()
    {
        Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    }
}