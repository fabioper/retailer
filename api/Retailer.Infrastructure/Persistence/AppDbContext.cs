using Microsoft.EntityFrameworkCore;
using Retailer.Core.DiscountPolicies;
using Retailer.Core.DiscountPolicies.Conditions;
using Retailer.Core.Sales;

namespace Retailer.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    private const string DefaultSchema = "retailer";

    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<DiscountPolicy> DiscountPolicies { get; set; }
    public DbSet<DiscountCondition> DiscountConditions { get; set; }
    public DbSet<MinimumTotalDiscountCondition> MinimumTotalDiscountConditions { get; set; }
    public DbSet<ProductDiscountCondition> ProductDiscountConditions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
