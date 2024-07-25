using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderDetailsServiceModel
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        [Display(Name = "Order number")]
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
        /// Order amount excluding shipping fee
        /// </summary>
        [Display(Name = "Order items total amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Order shipping fee
        /// </summary>
        [Display(Name = "Shipping fee")]
        public decimal ShippingFee { get; set; }

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
        /// Order address
        /// </summary>
        public OrderAddressDetailsModel OrderAddress { get; set; } = null!;

        /// <summary>
        /// Order recipient
        /// </summary>
        public OrderRecipientDetailsModel OrderRecipient { get; set; } = null!;

        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<OrderItemDetailsModel> OrderItems { get; set; } = new List<OrderItemDetailsModel>();
    }
}
