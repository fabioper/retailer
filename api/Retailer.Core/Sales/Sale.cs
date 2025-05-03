using Retailer.Common;

namespace Retailer.Core.Sales;

public class Sale : Entity<Guid>
{
    private readonly IList<SaleItem> _items = [];

    private Sale(SaleStatus status) : base(Guid.CreateVersion7())
    {
        Status = status;
    }

    public decimal Total => _items.Sum(item => item.Price * item.Quantity);

    public SaleStatus Status { get; private set; }

    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    public static Result<Sale> Create()
    {
        var sale = new Sale(SaleStatus.InProgress);
        return Result.Ok(sale);
    }

    public Result AddItem(Guid productId, decimal price, int quantity)
    {
        var createItemResult = SaleItem.Create(productId, price, quantity);

        if (createItemResult.IsFailed)
            return Result.Fail(createItemResult.Errors);

        _items.Add(createItemResult.Value);
        return Result.Ok();
    }

    public Result Complete()
    {
        if (!_items.Any())
            return Result.Fail(DomainErrors.CannotCloseEmptySale());

        Status = SaleStatus.Completed;
        return Result.Ok();
    }

    public bool IsCompleted() => Status == SaleStatus.Completed;
}