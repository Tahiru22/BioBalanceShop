using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.AddressData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Customer address data entity
    /// </summary>
    public class CustomerAddress
    {
        /// <summary>
        /// Customer address identificator
        /// </summary>
        [Key]
        [Comment("Customer address identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if customer address exists
        /// </summary>
        [Required]
        [PersonalData]
        [Comment("Indicator if customer address exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Customer address street name
        /// </summary>
        [MaxLength(StreetMaxLength)]
        [PersonalData]
        [Comment("Customer address street name")]
        public string? Street { get; set; } = string.Empty;

        /// <summary>
        /// Customer address post code
        /// </summary>
        [MaxLength(PostCodeMaxLength)]
        [PersonalData]
        [Comment("Customer address post code")]
        public string? PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Customer address city
        /// </summary>
        [MaxLength(CityMaxLength)]
        [PersonalData]
        [Comment("Customer address city")]
        public string? City { get; set; } = string.Empty;

        /// <summary>
        /// Customer address country identificator
        /// </summary>
        [PersonalData]
        [Comment("Customer address country identificator")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Customer address country
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        [PersonalData]
        public Country? Country { get; set; } = null!;
    }
}