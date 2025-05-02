namespace PontoDeVenda.Core.Order;

public interface IOrdersRepository
{
    Task<Order> AddAsync(Order order);

    Task<Order?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}