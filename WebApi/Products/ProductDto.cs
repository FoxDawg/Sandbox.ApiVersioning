using WebApi.Products.Model;

namespace WebApi.Products;

public class ProductDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }

    public static ProductDto FromProduct(Product product)
    {
        return new ProductDto()
        {
            Name = product.Name,
            Description = product.Description
        };
    }
}