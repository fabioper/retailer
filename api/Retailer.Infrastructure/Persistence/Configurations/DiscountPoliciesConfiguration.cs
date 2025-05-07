using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retailer.Core.DiscountPolicies;
using Retailer.Core.DiscountPolicies.Policies;

namespace Retailer.Infrastructure.Persistence.Configurations;

public class DiscountPoliciesConfiguration : IEntityTypeConfiguration<DiscountPolicy>
{
    public void Configure(EntityTypeBuilder<DiscountPolicy> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.HasDiscriminator<string>("DiscountPolicyType")
            .HasValue<FixedAmountDiscountPolicy>(nameof(FixedAmountDiscountPolicy))
            .HasValue<PercentageDiscountPolicy>(nameof(PercentageDiscountPolicy));

        builder.HasMany(x => x.Conditions)
            .WithOne()
            .HasForeignKey("DiscountPolicyId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.Name).IsRequired();

        builder.Navigation(x => x.Conditions).AutoInclude();
    }
}
