using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace coffeecapp.Services.Catalog.API.Model;

public class CatalogItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; } 
    public string Picture { get; set; } = null!;
    public int CatalogTypeId { get; set; } 
    public CatalogType? CatalogType { get; set; } = null!;
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public int MaxStockThreshold { get; set; }
    public bool OnReorder { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
