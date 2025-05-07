using Retailer.Common;

namespace Retailer.Core.Products;

public sealed class Product : Entity<Guid>
{
    private Product(string name, decimal price) : base(Guid.CreateVersion7())
    {
        Name = name;
        Price = price;
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public static Result<Product> Create(string name, decimal price)
    {
        return Result.Ok(new Product(name, price));
    }
}
