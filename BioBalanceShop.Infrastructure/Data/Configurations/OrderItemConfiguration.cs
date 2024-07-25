using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasQueryFilter(oi => oi.IsActive);

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Currency)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(oi => oi.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new OrderItem[] {
                data.GreenNourishCompleteOrderItem,
                data.AppleCiderVinegarComplexOrderItem
            });
        }
    }
}
