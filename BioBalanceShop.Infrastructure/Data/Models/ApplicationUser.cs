using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ApplicationUserData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// ApplicationUser extension data entity
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Indicator if user exists
        /// </summary>
        [Required]
        [Comment("Indicator if user exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// User first name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [PersonalData]
        [Comment("User first name")]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User last name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [PersonalData]
        [Comment("User last name")]
        public string? LastName { get; set; } = string.Empty;

        /// <summary>
        /// Date when user was created
        /// </summary>
        [Required]
        [Comment("Date when user was created")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        public Customer? Customer { get; set; }
    }
}
