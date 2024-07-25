using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.HasQueryFilter(osa => osa.IsActive);

            builder.HasOne(osa => osa.Country)
                .WithMany(c => c.OrderAddresses)
                .HasForeignKey(osa => osa.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new OrderAddress[] {
                data.IvanIvanovOrderAddress
            });
        }
    }
}
