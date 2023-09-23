using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Products;
using WebApi.Products.Model;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion(1.0, Deprecated = true)]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]

public class ProductsController : ControllerBase
{
    private readonly ProductsService productsService;

    public ProductsController(ProductsService productsService)
    {
        this.productsService = productsService;
    }

    [HttpGet("{productId}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetProductById([FromRoute] int productId)
    {
        var product = await this.productsService.FindProductByIdAsync(productId);
        
        return product is null 
            ? this.NoContent() 
            : this.Ok(product);
    }
    
    [HttpGet("{productName}")]
    [MapToApiVersion(2.0)]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetProductByName([FromRoute] string productName)
    {
        var product = await this.productsService.FindProductByNameAsync(productName);
        
        return product is null 
            ? this.NoContent() 
            : this.Ok(product);
    }
    
    
}