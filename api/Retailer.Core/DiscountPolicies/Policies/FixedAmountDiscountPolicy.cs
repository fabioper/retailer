using Retailer.Core.Sales;

namespace Retailer.Core.DiscountPolicies.Policies;

public class FixedAmountDiscountPolicy(string name, decimal fixedAmount, bool isActive) : DiscountPolicy(name, isActive)
{
    public decimal FixedAmount { get; private set; } = fixedAmount;

    public override decimal CalculateDiscountOf(Sale sale) => sale.Total - FixedAmount;
}
