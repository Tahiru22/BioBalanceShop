using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderAddressDetailsModel
    {
        /// <summary>
        /// Order address identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order address street name
        /// </summary>
        [PersonalData]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Order address post code
        /// </summary>
        [PersonalData]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Order address city
        /// </summary>
        [PersonalData]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Order address country
        /// </summary>
        [PersonalData]
        public string Country { get; set; } = null!;
    }
}