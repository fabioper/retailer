namespace Retailer.Core.DiscountPolicies;

public interface IDiscountPoliciesRepository
{
    Task<IEnumerable<DiscountPolicy>> GetAvailableDiscounts();
    Task<DiscountPolicy> AddAsync(DiscountPolicy discountPolicy);
    Task SaveChangesAsync();
}
