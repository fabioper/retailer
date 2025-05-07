using Retailer.Core.Sales;

namespace Retailer.Core.DiscountPolicies.Policies;

public class PercentageDiscountPolicy(string name, decimal percentage, bool isActive) : DiscountPolicy(name, isActive)
{
    public decimal Percentage { get; private set; } = percentage;

    public override decimal CalculateDiscountOf(Sale sale) => sale.Total * Percentage / 100;
}
