using BioBalanceShop.Core.Models.Customer;

namespace BioBalanceShop.Core.Contracts
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(string userId);

        Task<int?> GetCustomerIdByUserIdAsync(string userId);

        Task<bool> IsCustomer(string userId);

        Task<bool> CustomerAddressExists(string userId);
        Task<CustomerAddressServiceModel?> GetCustomerAddress(string userId);

        Task<CustomerAddressFormModel?> GetCustomerAddressFormModel(string userId);

        Task EditCustomerAddressAsync(CustomerAddressFormModel model, string userId);

        Task CreateCustomerAddressAsync(CustomerAddressFormModel model, string userId);
    }
}
