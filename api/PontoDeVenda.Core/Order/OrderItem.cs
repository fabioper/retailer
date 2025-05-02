using PontoDeVenda.Common;

namespace PontoDeVenda.Core.Order;

public class OrderItem : Entity<Guid>
{
    private OrderItem(Guid id, decimal price, int quantity) : base(id)
    {
        Price = price;
        Quantity = quantity;
    }

    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public static Result<OrderItem> Create(Guid productId, decimal price, int quantity)
    {
        if (price <= 0)
            return Result.Fail(DomainErrors.InvalidPriceForOrderItem(price));

        if (quantity <= 0)
            return Result.Fail(DomainErrors.InvalidQuantityForOrderItem(quantity));

        return Result.Ok(new OrderItem(productId, price, quantity));
    }
}