using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasQueryFilter(csa => csa.IsActive);

            builder.HasOne(csa => csa.Country)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new CustomerAddress[] {
                data.IvanIvanovAddress
            });
        }
    }
}
