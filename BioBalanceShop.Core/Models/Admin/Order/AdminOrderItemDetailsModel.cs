namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderItemDetailsModel
    {
        /// <summary>
        /// Order item identificator
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Order item name
        /// </summary>
        public string? Title { get; set; } = string.Empty;

        /// <summary>
        /// Order item image URL
        /// </summary>
        public string? ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Order item quantity
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Order item price
        /// </summary>
        public decimal? Price { get; set; }
    }
}
