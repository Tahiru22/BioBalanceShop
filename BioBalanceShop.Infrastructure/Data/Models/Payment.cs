using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Payment data entity
    /// </summary>
    public  class Payment
    {
        /// <summary>
        /// Payment identificator
        /// </summary>
        [Key]
        [Comment("Payment identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Payment date
        /// </summary>
        [Required]
        [Comment("Payment date")]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Payment amount
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Payment amount")]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Payment status
        /// </summary>
        [Required]
        [EnumDataType(typeof(PaymentStatus))]
        [Comment("Payment status")]
        public PaymentStatus PaymentStatus { get; set; }
    }
}
