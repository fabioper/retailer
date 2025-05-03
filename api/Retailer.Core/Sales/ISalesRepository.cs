namespace Retailer.Core.Sales;

public interface ISalesRepository
{
    Task<Sale> AddAsync(Sale sale);

    Task<Sale?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}