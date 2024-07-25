using BioBalanceShop.Core.Models._Base;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.OrderData;

namespace BioBalanceShop.Core.Models.Payment
{
    public class CheckoutOrderFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            AmountMinValue,
            AmountMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Order Amount")]
        public decimal OrderAmount { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
           AmountMinValue,
           AmountMaxValue,
           ConvertValueInInvariantCulture = true,
           ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Shipping Fee")]
        public decimal ShippingFee { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
           AmountMinValue,
           AmountMaxValue,
           ConvertValueInInvariantCulture = true,
           ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Total Order Amount")]
        public decimal TotalOrderAmount => OrderAmount + ShippingFee;

        [Required(ErrorMessage = RequiredMessage)]
        public ShopCurrencyServiceModel Currency { get; set; } = null!;
    }
}
