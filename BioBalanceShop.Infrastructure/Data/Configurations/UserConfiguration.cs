using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasQueryFilter(u => u.IsActive);

            var data = new SeedData();

            builder.HasData(new ApplicationUser[] {
                data.AdminUser,
                data.CustomerUser
            });
        }
    }
}
