using coffeecapp.Services.Catalog.API.Model;
using coffeecapp.Services.Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace coffeecapp.Services.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogService _catalogService;

    public CatalogController(CatalogService catalogService) =>
        _catalogService = catalogService;

    [HttpGet]
    public async Task<List<CatalogItem>> Get() =>
        await _catalogService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CatalogItem>> Get(string id)
    {
        var catalog = await _catalogService.GetAsync(id);

        if (catalog is null)
        {
            return NotFound();
        }

        return catalog;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CatalogItem newCatalogItem)
    {
        await _catalogService.CreateAsync(newCatalogItem);

        return CreatedAtAction(nameof(Get), new { id = newCatalogItem.Id }, newCatalogItem);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CatalogItem updatedCatalogItem)
    {
        var catalog = await _catalogService.GetAsync(id);

        if (catalog is null)
        {
            return NotFound();
        }

        updatedCatalogItem.Id = catalog.Id;

        await _catalogService.UpdateAsync(id, updatedCatalogItem);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var catalog = await _catalogService.GetAsync(id);

        if (catalog is null)
        {
            return NotFound();
        }

        await _catalogService.RemoveAsync(id);

        return NoContent();
    }

}