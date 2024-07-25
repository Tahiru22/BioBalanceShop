using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.CurrencyData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Currency data entity
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Currency identificator
        /// </summary>
        [Key]
        [Comment("Currency identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if currency exists
        /// </summary>
        [Required]
        [Comment("Indicator if currency exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Currency code
        /// </summary>
        [Required]
        [MaxLength(CurrencyCodeMaxLength)]
        [RegularExpression(CurrencyCodeRegexPattern)]
        [Comment("Currency code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Currency symbol
        /// </summary>
        [Required]
        [MaxLength(CurrencySymbolMaxLength)]
        [Comment("Currency symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Indicator if the currency symbol is displayed before or after price
        /// </summary>
        [Required]
        [Comment("Indicator if the currency symbol is displayed before or after price")]
        public bool IsSymbolPrefix { get; set; } = true;

        /// <summary>
        /// Orders
        /// </summary>
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
