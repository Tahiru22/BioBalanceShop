using BioBalanceShop.Core.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.AddressData;

namespace BioBalanceShop.Core.Models.Customer
{
    public class CustomerAddressFormModel
    {
        [StringLength(StreetMaxLength,
            MinimumLength = StreetMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Street")]
        [PersonalData]
        public string? Street { get; set; } = string.Empty;

        [StringLength(PostCodeMaxLength,
            MinimumLength = PostCodeMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Post code")]
        [PersonalData]
        public string? PostCode { get; set; } = string.Empty;

        [StringLength(CityMaxLength,
            MinimumLength = CityMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "City")]
        [PersonalData]
        public string? City { get; set; } = string.Empty;

        [Display(Name = "Country")]
        [PersonalData]
        public CustomerAddressCountryFormModel? Country { get; set; } = null!;

        public IList<ShopCountryServiceModel> Countries { get; set; } = new List<ShopCountryServiceModel>();
    }
}
