using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderAllServiceModel
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        public string OrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order date
        /// </summary>
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [Display(Name = "Order status")]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order total amount including shipping fee
        /// </summary>
        [Display(Name = "Order total amount")]
        public decimal TotalAmount { get; set; }
      
        /// <summary>
        /// Order currency
        /// </summary>
        public ShopCurrencyServiceModel Currency { get; set; } = null!;

        /// <summary>
        /// Order items count
        /// </summary>
        public int OrderItemsCount { get; set; }
    }
}
