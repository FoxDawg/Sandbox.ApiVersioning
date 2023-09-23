using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Products.Model;

namespace WebApi.Products;

public class ProductsService
{
    private readonly static IList<Product> Products = new List<Product>
    {
        new(1, "Hat", "The only available hat"),
        new(2, "Coffee Grinder", "Breaks beans in perfect halves")
    };

    public async Task<Product?> FindProductByIdAsync(int id)
    {
        await Task.CompletedTask;
        return Products.FirstOrDefault(o => o.Id == id);
    }
    
    public async Task<IReadOnlyCollection<Product>> FindProductsByNameAsync(string name)
    {
        await Task.CompletedTask;
        return Products
            .Where(o => o.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    
    public async Task<IReadOnlyCollection<Product>> FindProductsByDescriptionAsync(string name)
    {
        await Task.CompletedTask;
        return Products
            .Where(o => o.Description.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}