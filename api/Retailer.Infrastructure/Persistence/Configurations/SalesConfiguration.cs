using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retailer.Core.Sales;

namespace Retailer.Infrastructure.Persistence.Configurations;

public class SalesConfiguration : IEntityTypeConfiguration<Sale>
{
    private const string? TableName = "Sales";

    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Status).IsRequired();

        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey("SaleId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Items).AutoInclude();
    }
}