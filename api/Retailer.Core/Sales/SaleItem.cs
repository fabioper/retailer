using Retailer.Common;

namespace Retailer.Core.Sales;

public class SaleItem : Entity<Guid>
{
    private SaleItem(Guid id, decimal price, int quantity) : base(id)
    {
        Price = price;
        Quantity = quantity;
    }

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
}