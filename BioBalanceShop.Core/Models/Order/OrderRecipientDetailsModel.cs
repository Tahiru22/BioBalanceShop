using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderRecipientDetailsModel
    {
        /// <summary>
        /// Order recipient identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order recipient first name
        /// </summary>
        [Display(Name = "First name")]
        [PersonalData]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient last name
        /// </summary>
        [Display(Name = "Last name")]
        [PersonalData]
        public string? LastName { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient phone number
        /// </summary>
        [Display(Name = "Phone")]
        [PersonalData]
        public string? PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient email address
        /// </summary>
        [Display(Name = "Email")]
        [PersonalData]
        public string? EmailAddress { get; set; } = string.Empty;
    }
}