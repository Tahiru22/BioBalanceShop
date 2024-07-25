using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Shared
{
    public class ShopCountryServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        public string Name { get; set; } = string.Empty;
    }
}
