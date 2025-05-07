using Microsoft.EntityFrameworkCore;
using Retailer.Core.Sales;

namespace Retailer.Infrastructure.Persistence.Repositories;

public class SalesRepository(AppDbContext context) : ISalesRepository
{
    private DbSet<Sale> Sales => context.Set<Sale>();

    public async Task<Sale> AddAsync(Sale sale)
    {
        var result = await Sales.AddAsync(sale);
        return result.Entity;
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {
        return await Sales.AsNoTracking().FirstOrDefaultAsync(sale => sale.Id == id);
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}
