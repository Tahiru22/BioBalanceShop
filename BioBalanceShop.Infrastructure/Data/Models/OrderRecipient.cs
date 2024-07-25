using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ApplicationUserData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order recipient entity
    /// </summary>
    public class OrderRecipient
    {
        /// <summary>
        /// Order recipient identificator
        /// </summary>
        [Key]
        [Comment("Order recipient identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if order recipient exists
        /// </summary>
        [Required]
        [Comment("Indicator if order recipient exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Order recipient first name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [PersonalData]
        [Comment("Order recipient first name")]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient last name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [PersonalData]
        [Comment("Order recipient last name")]
        public string? LastName { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient phone number
        /// </summary>
        [MaxLength(PhoneMaxLength)]
        [RegularExpression(PhoneRegexPattern)]
        [PersonalData]
        [Comment("Order recipient phone number")]
        public string? PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient email address
        /// </summary>
        [MaxLength(EmailMaxLength)]
        [RegularExpression(EmailRegexPattern)]
        [PersonalData]
        [Comment("Order recipient phone number")]
        public string? EmailAddress { get; set; } = string.Empty;
    }
}
