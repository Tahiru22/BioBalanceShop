using Microsoft.AspNetCore.Identity;

namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderAddressDetailsModel
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
