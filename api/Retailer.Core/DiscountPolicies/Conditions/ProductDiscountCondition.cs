using Retailer.Core.Sales;

namespace Retailer.Core.DiscountPolicies.Conditions;

public class ProductDiscountCondition(Guid productId) : DiscountCondition
{
    public Guid ProductId { get; private set; }

    public override bool IsSatisfiedBy(Sale sale) => sale.Items.Any(x => x.ProductId == productId);
}
