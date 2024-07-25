using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.CategoryData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Product category data entity
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Product category identificator
        /// </summary>
        [Key]
        [Comment("Product category identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if category exists
        /// </summary>
        [Required]
        [Comment("Indicator if category exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Product category name 
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Product category name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Products in the category
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}