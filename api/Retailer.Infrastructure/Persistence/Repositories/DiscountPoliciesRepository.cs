using Microsoft.EntityFrameworkCore;
using Retailer.Core.DiscountPolicies;

namespace Retailer.Infrastructure.Persistence.Repositories;

public class DiscountPoliciesRepository(AppDbContext context) : IDiscountPoliciesRepository
{
    private DbSet<DiscountPolicy> DiscountPolicies => context.Set<DiscountPolicy>();

    public async Task<IEnumerable<DiscountPolicy>> GetAvailableDiscounts()
    {
        var discountPolicies = await DiscountPolicies
            .Where(x => x.IsActive)
            .ToListAsync();

        return discountPolicies;
    }

    public async Task<DiscountPolicy> AddAsync(DiscountPolicy discountPolicy)
    {
        var result = await DiscountPolicies.AddAsync(discountPolicy);
        return result.Entity;
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}
