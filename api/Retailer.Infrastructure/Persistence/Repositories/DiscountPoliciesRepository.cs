using Microsoft.EntityFrameworkCore;
using Retailer.Core.DiscountPolicies;

namespace Retailer.Infrastructure.Persistence.Repositories;

public class DiscountPoliciesRepository(DbContext context) : IDiscountPoliciesRepository
{
    private DbSet<DiscountPolicy> DiscountPolicies => context.Set<DiscountPolicy>();

    public async Task<IEnumerable<DiscountPolicy>> GetAvailableDiscounts()
    {
        var discountPolicies = await DiscountPolicies
            .Where(x => x.IsActive)
            .ToListAsync();

        return discountPolicies;
    }
}
