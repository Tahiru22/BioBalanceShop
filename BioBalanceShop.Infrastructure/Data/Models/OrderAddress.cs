using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.AddressData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order address data entity
    /// </summary>
    public class OrderAddress
    {
        /// <summary>
        /// Order address identificator
        /// </summary>
        [Key]
        [Comment("Order address identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if order address exists
        /// </summary>
        [Required]
        [Comment("Indicator if order address exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Order address street name
        /// </summary>
        [Required]
        [MaxLength(StreetMaxLength)]
        [Comment("Order address street name")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Order address post code
        /// </summary>
        [Required]
        [MaxLength(PostCodeMaxLength)]
        [Comment("Order address post code")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Order address city
        /// </summary>
        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("Order address city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Order address country identificator
        /// </summary>
        [Required]
        [Comment("Order address country identificator")]
        public int CountryId { get; set; }

        /// <summary>
        /// Order address country
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}