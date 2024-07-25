using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.MessageConstants;

namespace BioBalanceShop.Core.Models.Payment
{
    public class CheckoutFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        public CheckoutCustomerFormModel Customer { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        public CheckoutOrderFormModel Order { get; set; } = null!;
    }
}
