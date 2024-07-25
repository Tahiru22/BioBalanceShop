using BioBalanceShop.Core.Models.Payment;

namespace BioBalanceShop.Core.Contracts
{
    public interface IPaymentService
    {
        Task<bool> ExistsAsync(string userId);
        Task<CheckoutCustomerFormModel> GetCustomerInfoAsync(string userId);
        Task CreatePaymentAsync(PaymentServiceModel model);
    }
}
