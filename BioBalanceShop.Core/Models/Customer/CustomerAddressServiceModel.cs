using BioBalanceShop.Core.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Customer
{
    public class CustomerAddressServiceModel
    {
        [Display(Name = "Street")]
        [PersonalData]
        public string Street { get; set; } = string.Empty;

        [Display(Name = "Post code")]
        [PersonalData]
        public string PostCode { get; set; } = string.Empty;

        [Display(Name = "City")]
        [PersonalData]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Country")]
        public ShopCountryServiceModel Country { get; set; } = null!;
    }
}
