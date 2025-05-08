using Microsoft.EntityFrameworkCore;
using Retailer.Core.Products;

namespace Retailer.Infrastructure.Persistence.Repositories;

public class ProductsRepository(AppDbContext context) : IProductsRepository
{
    private DbSet<Product> Products => context.Products;

    public async Task<Product> AddProductAsync(Product product)
    {
        var result = await Products.AddAsync(product);
        return result.Entity;
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await Products.AsNoTracking().ToListAsync();
}
