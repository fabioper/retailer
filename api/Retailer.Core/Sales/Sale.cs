using Retailer.Common;
using Retailer.Core.DiscountPolicies;

namespace Retailer.Core.Sales;

public class Sale : Entity<Guid>
{
    private readonly IList<Discount> _appliedDiscounts = [];
    private readonly IList<SaleItem> _items = [];

    private Sale(SaleStatus status) : base(Guid.CreateVersion7())
    {
        Status = status;
    }

    public SaleStatus Status { get; private set; }

    public decimal Total => _items.Sum(item => item.Price * item.Quantity);

    public decimal TotalDiscounts => _appliedDiscounts.Sum(d => d.Total);

    public decimal Subtotal => Total - TotalDiscounts;

    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    public IReadOnlyCollection<Discount> AppliedDiscounts => _appliedDiscounts.AsReadOnly();

    public bool IsInProgress => Status == SaleStatus.InProgress;

    public bool IsCompleted => Status == SaleStatus.Completed;

    public static Result<Sale> Start()
    {
        var sale = new Sale(SaleStatus.InProgress);
        return Result.Ok(sale);
    }

    public Result AddItem(Guid productId, decimal price, int quantity)
    {
        if (!IsInProgress)
            return Result.Fail(DomainErrors.CannotAddItemToSaleThatIsNotInProgress());

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

    public void ApplyDiscountPolicies(IEnumerable<DiscountPolicy> policies)
    {
        foreach (var policy in policies)
        {
            var discount = policy.CalculateDiscountOf(this);
            if (discount > 0)
                _appliedDiscounts.Add(new Discount(policy.Id, discount));
        }
    }
}
