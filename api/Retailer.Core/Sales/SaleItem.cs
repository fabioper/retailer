using Retailer.Common;

namespace Retailer.Core.Sales;

public class SaleItem : Entity<Guid>
{
    private SaleItem(Guid productId, decimal price, int quantity) : base(Guid.CreateVersion7())
    {
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public Guid ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public static Result<SaleItem> Create(Guid productId, decimal price, int quantity)
    {
        if (price <= 0)
            return Result.Fail(DomainErrors.InvalidPriceForSaleItem(price));

        if (quantity <= 0)
            return Result.Fail(DomainErrors.InvalidQuantityForSaleItem(quantity));

        return Result.Ok(new SaleItem(productId, price, quantity));
    }

    public Result IncreaseQuantityBy(int quantity)
    {
        if (quantity <= 0) return Result.Fail(DomainErrors.InvalidQuantityForSaleItem(quantity));

        Quantity += quantity;

        return Result.Ok();
    }
}
