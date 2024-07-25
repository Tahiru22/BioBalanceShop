using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Shop data entity
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Shop identificator
        /// </summary>
        [Key]
        [Comment("Shop identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if shop exists
        /// </summary>
        [Required]
        [Comment("Indicator if shop exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Shop currency
        /// </summary>
        [Required]
        [Comment("Shop currency identificator")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Shipping fee rate applied to order amount
        /// </summary>
        [Comment("Shipping fee rate applied to order amount")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ShippingFeeRate { get; set; }

        /// <summary>
        /// Shop currency
        /// </summary>
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; } = null!;

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}