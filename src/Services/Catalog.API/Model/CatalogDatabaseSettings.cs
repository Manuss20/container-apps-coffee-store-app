namespace coffeecapp.Services.Catalog.API.Model;

public class CatalogDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CatalogCollectionName { get; set; } = null!;
}
