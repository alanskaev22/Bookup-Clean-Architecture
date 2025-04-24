using Microsoft.AspNetCore.Mvc;

namespace Api;

[Route("api/[controller]")]
[ApiController]
public sealed class ProductsCatalogController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var data = new List<string> { "Product1", "Product2", "Product3" };

        return Ok(await Task.FromResult(data));
    }
}