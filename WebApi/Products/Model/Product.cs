namespace WebApi.Products.Model;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }

    public Product(int id, string name, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
    }
}