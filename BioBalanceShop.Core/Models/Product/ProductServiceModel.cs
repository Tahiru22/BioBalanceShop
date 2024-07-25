using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models._Base;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Product
{
    public class ProductServiceModel : IProductModel
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Price")]
        public decimal Price { get; set; }
        
        public ShopCurrencyServiceModel Currency { get; set; } = null!;

    }
}