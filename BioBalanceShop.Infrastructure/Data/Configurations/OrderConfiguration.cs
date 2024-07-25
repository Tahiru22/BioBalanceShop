using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasQueryFilter(o => o.IsActive);

            builder.HasIndex(o => o.OrderNumber)
                .IsUnique();

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Currency)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.OrderNumber)
            .ValueGeneratedNever();

            var data = new SeedData();

            builder.HasData(new Order[] {
                data.IvanIvanovOrder
            });
        }
    }
}
