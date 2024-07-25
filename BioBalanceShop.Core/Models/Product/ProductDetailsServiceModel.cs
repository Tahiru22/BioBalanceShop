using BioBalanceShop.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Product
{
    public class ProductDetailsServiceModel : IProductModel
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Subtitle")]
        public string Subtitle { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        public int QuantityToOrder { get; set; }

        public int QuantityInStock { get; set; }

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
