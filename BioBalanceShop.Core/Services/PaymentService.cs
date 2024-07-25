using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Core.Models.Shared;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository _repository;
        private readonly ICustomerService _customerService;
        public PaymentService(
            IRepository repository,
            ICustomerService customerService)
        {
            _repository = repository;
            _customerService = customerService;
        }

        public async Task CreatePaymentAsync(PaymentServiceModel model)
        {
            await _repository.AddAsync(model);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string userId)
        {
            return await _repository.AllReadOnly<Customer>()
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task<CheckoutCustomerFormModel> GetCustomerInfoAsync(string userId)
        {
            var customer = await _repository.AllReadOnly<ApplicationUser>()
                .Where(c => c.Id == userId)
                .Select(c => new CheckoutCustomerFormModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Country = new ShopCountryServiceModel()
                })
                .FirstAsync();

            if (await _customerService.CustomerAddressExists(userId))
            {
                var address = await _customerService.GetCustomerAddress(userId);

                if (address != null)
                {
                    customer.Street = address.Street;
                    customer.PostCode = address.PostCode;
                    customer.City = address.City;
                    customer.Country.Id = address.Country.Id;
                    customer.Country.Name = address.Country.Name;
                }
            }
            
            return customer;
        }
    }
}
