namespace Retailer.Core.DiscountPolicies;

public interface IDiscountPoliciesRepository
{
    Task<IEnumerable<DiscountPolicy>> GetAvailableDiscounts();
}
