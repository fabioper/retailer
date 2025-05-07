using Retailer.Common;
using Retailer.Core.Sales;

namespace Retailer.Core.DiscountPolicies;

public abstract class DiscountCondition() : Entity<Guid>(Guid.CreateVersion7())
{
    public abstract bool IsSatisfiedBy(Sale sale);
}