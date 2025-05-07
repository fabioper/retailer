using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retailer.Core.DiscountPolicies;

namespace Retailer.Infrastructure.Persistence.Configurations;

public class DiscountConditionConfiguration : IEntityTypeConfiguration<DiscountCondition>
{
    public void Configure(EntityTypeBuilder<DiscountCondition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.UseTptMappingStrategy();
    }
}