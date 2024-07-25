using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderItemDetailsModel
    {
        /// <summary>
        /// Order item identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order item name
        /// </summary>
        [Display(Name = "Product name")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Order item image URL
        /// </summary>
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Order item quantity
        /// </summary>
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Order item price
        /// </summary>
        [Display(Name = "Unit price")]
        public decimal Price { get; set; }
    }
}