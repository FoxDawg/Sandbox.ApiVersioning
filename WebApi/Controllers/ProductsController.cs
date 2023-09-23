using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Products;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion(1.0, Deprecated = true)]
[ApiVersion(2.0)]
[ApiVersion(2.1, status: "workinprogress")]
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
            : this.Ok(ProductDto.FromProduct(product));
    }

    [HttpGet]
    [MapToApiVersion(2.0)]
    [MapToApiVersion(2.1)]
    [ProducesResponseType(typeof(IList<ProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SearchByProductName([FromQuery] string productName)
    {
        var products = await this.productsService.FindProductsByNameAsync(productName);

        return products.Any() == false
            ? this.NoContent()
            : this.Ok(products.Select(ProductDto.FromProduct));
    }
}