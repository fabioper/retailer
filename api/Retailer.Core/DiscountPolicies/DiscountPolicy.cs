using Retailer.Common;
using Retailer.Core.Sales;

namespace Retailer.Core.DiscountPolicies;

public abstract class DiscountPolicy(string name, bool isActive) : Entity<Guid>(Guid.CreateVersion7())
{
    private readonly IList<DiscountCondition> _conditions = [];

    public string Name { get; private set; } = name;
    public bool IsActive { get; private set; } = isActive;
    public IReadOnlyCollection<DiscountCondition> Conditions => _conditions.AsReadOnly();

    public void AddCondition(DiscountCondition condition) => _conditions.Add(condition);

    public bool IsApplicable(Sale sale)
    {
        return IsActive && _conditions.All(c => c.IsSatisfiedBy(sale));
    }

    public abstract decimal CalculateDiscountOf(Sale sale);
}
