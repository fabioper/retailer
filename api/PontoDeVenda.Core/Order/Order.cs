using PontoDeVenda.Common;

namespace PontoDeVenda.Core.Order;

public class Order : Entity<Guid>
{
    private readonly IList<OrderItem> _items = [];

    private Order(OrderStatus status) : base(Guid.CreateVersion7())
    {
        Status = status;
    }

    public decimal Total => _items.Sum(item => item.Price * item.Quantity);

    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public static Result<Order> Create()
    {
        var order = new Order(OrderStatus.InProgress);
        return Result.Ok(order);
    }

    public Result AddItem(Guid productId, decimal price, int quantity)
    {
        var createItemResult = OrderItem.Create(productId, price, quantity);

        if (createItemResult.IsFailed)
            return Result.Fail(createItemResult.Errors);

        _items.Add(createItemResult.Value);
        return Result.Ok();
    }

    public Result Close()
    {
        if (!_items.Any())
            return Result.Fail(DomainErrors.CannotCloseEmptyOrder());

        Status = OrderStatus.Closed;

        return Result.Ok();
    }

    public bool IsClosed() => Status == OrderStatus.Closed;
}