using Microsoft.EntityFrameworkCore;
using PontoDeVenda.Core.Order;

namespace PontoDeVenda.Infrastructure.Persistence.Repositories;

public class OrdersRepository(DbContext context) : IOrdersRepository
{
    private DbSet<Order> Orders => context.Set<Order>();

    public async Task<Order> AddAsync(Order order)
    {
        var result = await Orders.AddAsync(order);
        return result.Entity;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await Orders.AsNoTracking().FirstOrDefaultAsync(order => order.Id == id);
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}