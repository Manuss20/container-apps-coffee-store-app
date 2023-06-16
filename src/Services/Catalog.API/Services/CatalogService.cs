using coffeecapp.Services.Catalog.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace coffeecapp.Services.Catalog.API.Services;

public class CatalogService
{
    private readonly IMongoCollection<CatalogItem> _catalogCollection;

    public CatalogService(
        IOptions<CatalogDatabaseSettings> catalogDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            catalogDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            catalogDatabaseSettings.Value.DatabaseName);

        _catalogCollection = mongoDatabase.GetCollection<CatalogItem>(
            catalogDatabaseSettings.Value.CatalogCollectionName);
    }

    public async Task<List<CatalogItem>> GetAsync() =>
        await _catalogCollection.Find(_ => true).ToListAsync();

    public async Task<CatalogItem?> GetAsync(string id) =>
        await _catalogCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(CatalogItem newCatalogItem) =>
        await _catalogCollection.InsertOneAsync(newCatalogItem);

    public async Task UpdateAsync(string id, CatalogItem updatedCatalogItem) =>
        await _catalogCollection.ReplaceOneAsync(x => x.Id == id, updatedCatalogItem);

    public async Task RemoveAsync(string id) =>
        await _catalogCollection.DeleteOneAsync(x => x.Id == id);

}