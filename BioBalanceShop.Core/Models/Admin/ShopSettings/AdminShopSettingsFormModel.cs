using BioBalanceShop.Core.Models._Base;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.OrderData;


namespace BioBalanceShop.Core.Models.Admin.ShopSettings
{
    public class AdminShopSettingsFormModel
    {
        /// <summary>
        /// Shop currency
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        public IEnumerable<ShopCurrencyServiceModel> Currencies { get; set; } = new List<ShopCurrencyServiceModel>();

        /// <summary>
        /// Shipping fee rate applied to order amount
        /// </summary>
        [Display(Name = "Shipping fee:")]
        [Range(typeof(decimal),
            ShipppingFeeMinValue,
            ShipppingFeeMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        public decimal? ShippingFeeRate { get; set; }

    }
}
