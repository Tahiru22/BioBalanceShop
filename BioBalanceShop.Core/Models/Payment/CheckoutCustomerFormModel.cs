using BioBalanceShop.Core.Models.Shared;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.AddressData;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ApplicationUserData;

namespace BioBalanceShop.Core.Models.Payment
{
    public class CheckoutCustomerFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [EmailAddress]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Phone]
        [StringLength(PhoneMaxLength, 
            MinimumLength = PhoneMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(StreetMaxLength,
            MinimumLength = StreetMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Street")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostCodeMaxLength,
            MinimumLength = PostCodeMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Post code")]
        public string PostCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CityMaxLength,
            MinimumLength = CityMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Country")]
        public ShopCountryServiceModel Country { get; set; } = null!;

        public IList<ShopCountryServiceModel> Countries { get; set; } = new List<ShopCountryServiceModel>();
    }
}
