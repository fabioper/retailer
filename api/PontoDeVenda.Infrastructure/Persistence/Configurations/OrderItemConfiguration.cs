using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoDeVenda.Core.Order;

namespace PontoDeVenda.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    private const string? TableName = "OrderItems";

    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Price).IsRequired();

        builder.Property(x => x.Quantity).IsRequired();
    }
}