using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Product;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ProductData;

namespace BioBalanceShop.Core.Models.Admin.Product
{
    public class AdminProductEditFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProductCodeMaxLength,
            MinimumLength = ProductCodeMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Product code")]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Product name")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SubtitleMaxLength,
            MinimumLength = SubtitleMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Subtitle")]
        public string Subtitle { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(IngredeientsMaxLength,
            MinimumLength = IngredeientsMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ImageUrlMaxLength,
            MinimumLength = ImageUrlMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(int),
            QuantityMinRange,
            QuantityMaxRange,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Stock quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            PriceMinRange,
            PriceMaxRange,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Unit price")]
        public decimal Price { get; set; }

        public ShopCurrencyServiceModel? Currency { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryAllServiceModel> Categories { get; set; } = new List<CategoryAllServiceModel>();
    }
}
