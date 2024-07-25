using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasQueryFilter(c => c.IsActive);

            var data = new SeedData();

            builder.HasData(new Country[] {
                data.Bulgaria,
                data.UnitedKingdom,
                data.UnitedStates,
                data.Germany,
                data.Spain
            });
        }
    }
}
