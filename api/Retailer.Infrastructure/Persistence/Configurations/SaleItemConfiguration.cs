using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retailer.Core.Sales;

namespace Retailer.Infrastructure.Persistence.Configurations;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    private const string? TableName = "SaleItems";

    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Price).IsRequired();

        builder.Property(x => x.Quantity).IsRequired();
    }
}