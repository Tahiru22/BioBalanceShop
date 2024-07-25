using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ProductData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Product data entity
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product identificator
        /// </summary>
        [Key]
        [Comment("Product identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if product exists
        /// </summary>
        [Required]
        [Comment("Indicator if product exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Product code
        /// </summary>
        [Required]
        [MaxLength(ProductCodeMaxLength)]
        [Comment("Product code")]
        public string ProductCode { get; set; } = string.Empty;

        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Product name")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Product subtitle
        /// </summary>
        [Required]
        [MaxLength(SubtitleMaxLength)]
        [Comment("Product subtitle")]
        public string Subtitle { get; set; } = string.Empty;

        /// <summary>
        /// Product description
        /// </summary>
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Product description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Product ingredients
        /// </summary>
        [Required]
        [MaxLength(IngredeientsMaxLength)]
        [Comment("Product ingredients")]
        public string Ingredients { get; set; } = string.Empty;

        /// <summary>
        /// Product image URL
        /// </summary>
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Product image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Product quantity
        /// </summary>
        [Required]
        [Comment("Product quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Product price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Product category identificator
        /// </summary>
        [Required]
        [Comment("Product category identificator")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Date product was created
        /// </summary>
        [Required]
        [Comment("Date product was created")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Product creator identificator
        /// </summary>
        [Required]
        [Comment("Product creator identificator")]
        public string CreatedById { get; set; } = string.Empty;

        /// <summary>
        /// Shop identificator
        /// </summary>
        [Required]
        [Comment("Shop identificator")]
        public int ShopId { get; set; }

        /// <summary>
        /// Product category
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Product creator
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public ApplicationUser CreatedBy { get; set; } = null!;

        /// <summary>
        /// Shop
        /// </summary>
        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;
    }
}
