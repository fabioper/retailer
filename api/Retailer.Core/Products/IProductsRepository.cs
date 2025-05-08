namespace Retailer.Core.Products;

public interface IProductsRepository
{
    Task<Product> AddProductAsync(Product value);
    Task SaveChangesAsync();
    Task<IEnumerable<Product>> GetAllAsync();
}
