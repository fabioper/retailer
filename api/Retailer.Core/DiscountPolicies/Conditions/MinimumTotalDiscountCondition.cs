using Retailer.Core.Sales;

namespace Retailer.Core.DiscountPolicies.Conditions;

public class MinimumTotalDiscountCondition(decimal minTotal) : DiscountCondition
{
    public decimal MinTotal { get; private set; } = minTotal;

    public override bool IsSatisfiedBy(Sale sale) => sale.Total >= MinTotal;
}
