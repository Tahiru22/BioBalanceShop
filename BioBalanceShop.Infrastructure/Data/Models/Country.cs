using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.CountryData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Country data entity
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Country identificator
        /// </summary>
        [Key]
        [Comment("Country identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if country exists
        /// </summary>
        [Required]
        [Comment("Indicator if country exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Country name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Country name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Country code
        /// </summary>
        [Required]
        [MaxLength(CountryCodeMaxLength)]
        [RegularExpression(CountryCodeRegexPattern)]
        [Comment("Country code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// User addresses
        /// </summary>
        public IEnumerable<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        /// <summary>
        /// Order addresses
        /// </summary>
        public IEnumerable<OrderAddress> OrderAddresses { get; set; } = new List<OrderAddress>();
    }
}
