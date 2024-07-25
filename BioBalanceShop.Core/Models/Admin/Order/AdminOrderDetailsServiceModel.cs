using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;

namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderDetailsServiceModel
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        public string? OrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order date
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order statuses
        /// </summary>
        public IEnumerable<OrderStatus>? OrderStatuses { get; set; } = new List<OrderStatus>();

        /// <summary>
        /// Order amount excluding shipping fee
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Order shipping fee
        /// </summary>
        public decimal? ShippingFee { get; set; }

        /// <summary>
        /// Order total amount including shipping fee
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Order currency
        /// </summary>
        public ShopCurrencyServiceModel? Currency { get; set; } = null!;

        /// <summary>
        /// Order address
        /// </summary>
        public AdminOrderAddressDetailsModel? OrderAddress { get; set; } = null!;

        /// <summary>
        /// Order recipient
        /// </summary>
        public AdminOrderRecipientDetailsModel? OrderRecipient { get; set; } = null!;

        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<AdminOrderItemDetailsModel>? OrderItems { get; set; } = new List<AdminOrderItemDetailsModel>();  
    }
}
