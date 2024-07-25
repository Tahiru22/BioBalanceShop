using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasQueryFilter(c => c.IsActive);

            var data = new SeedData();

            builder.HasData(new Category[] {
                data.OrganicProducts,
                data.Superfoods,
                data.MuscleMass,
                data.ImmunitySupport,
                data.DietFoods
            });
        }
    }
}
