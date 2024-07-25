using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Customer data entity
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer identificator
        /// </summary>
        [Key]
        [Comment("Customer identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if customer exists
        /// </summary>
        [Required]
        [Comment("Indicator if customer exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// User identificator
        /// </summary>
        [Required]
        [Comment("User identificator")]
        public string UserId { get; set; }

        /// <summary>
        /// Customer address identificator
        /// </summary>
        [Comment("Customer address identificator")]
        public int? AddressId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// Customer address
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public CustomerAddress? Address { get; set; } = null!;

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}