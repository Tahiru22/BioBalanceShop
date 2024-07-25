using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasIndex(p => p.ProductCode)
                .IsUnique();

            builder.HasOne(p => p.Shop)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.ShopId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Category)
                .WithMany(cb => cb.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Product[] {
                data.GreenNourishComplete,
                data.MaxNourish,
                data.AcaiImmunoDefence,
                data.AppleCiderVinegarComplex,
                data.WheyNourishChocolateFlavour,
                data.PeaNourish,
                data.ProBioMax,
                data.NaturaC,
                data.MealTimeVanillaFlavour,
                data.FibreAndFull
            });
        }
    }
}
