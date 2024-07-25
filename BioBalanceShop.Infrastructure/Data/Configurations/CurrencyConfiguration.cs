using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasQueryFilter(c => c.IsActive);

            var data = new SeedData();

            builder.HasData(new Currency[] {
                data.BgnCurrency,
                data.EurCurrency,
                data.UsdCurrency,
                data.GbpCurrency
            });
        }
    }
}
