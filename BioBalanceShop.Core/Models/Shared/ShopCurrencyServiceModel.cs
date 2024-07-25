using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models._Base
{
    public class ShopCurrencyServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Currency Code")]
        public string CurrencyCode { get; set; } = string.Empty;

        [Display(Name = "Currency Symbol")]
        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
