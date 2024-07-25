using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderServiceModel
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        /// </summary>
        public string OrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order date
        /// </summary>
        [Required]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order total amount including shipping fee
        /// </summary>
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
