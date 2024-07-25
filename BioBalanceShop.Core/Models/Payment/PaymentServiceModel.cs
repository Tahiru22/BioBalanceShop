using BioBalanceShop.Infrastructure.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.CurrencyData;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.PaymentData;

namespace BioBalanceShop.Core.Models.Payment
{
    /// <summary>
    /// Create payment model
    /// </summary>
    public class PaymentServiceModel
    {
        /// <summary>
        /// Payment amount
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            PaymentAmountMinValue,
            PaymentAmountMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Payment amount")]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Payment status
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [EnumDataType(typeof(PaymentStatus))]
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Payment currency code
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [MaxLength(CurrencyCodeMaxLength)]
        [RegularExpression(CurrencyCodeRegexPattern)]
        public string CurrencyCode { get; set; } = string.Empty;
    }
}
