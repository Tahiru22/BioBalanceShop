using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Customer;
using BioBalanceShop.Core.Models.Shared;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;
        private readonly IShopService _shopService;

        public CustomerService(
            IRepository repository,
            IShopService shopService)
        {
            _repository = repository;
            _shopService = shopService;
        }
        public async Task CreateCustomerAsync(string userId)
        {
            var customer = new Customer()
            {
                UserId = userId
            };

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> CustomerAddressExists(string userId)
        {
            return await _repository.AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .AnyAsync(c => c.AddressId != null);
        }

        public async Task<CustomerAddressFormModel?> GetCustomerAddressFormModel(string userId)
        {
            return await _repository.AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new CustomerAddressFormModel()
                {
                    Street = c.Address.Street,
                    PostCode = c.Address.PostCode,
                    City = c.Address.City,
                    Country = new CustomerAddressCountryFormModel()
                    {
                        Id = c.Address.Country.Id,
                        Name = c.Address.Country.Name
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CustomerAddressServiceModel?> GetCustomerAddress(string userId)
        {
            return await _repository.AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new CustomerAddressServiceModel()
                {
                    Street = c.Address.Street,
                    PostCode = c.Address.PostCode,
                    City = c.Address.City,
                    Country = new ShopCountryServiceModel()
                    {
                        Id = c.Address.Country.Id,
                        Name = c.Address.Country.Name
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int?> GetCustomerIdByUserIdAsync(string userId)
        {
            var customer = await _repository
                .AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new { c.Id })
                .FirstOrDefaultAsync();

            return customer?.Id;
        }

        public async Task<bool> IsCustomer(string userId)
        {
            return await _repository.AllReadOnly<Customer>()
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task EditCustomerAddressAsync(CustomerAddressFormModel model, string userId)
        {
            var addressToEdit = await _repository.All<Customer>()
                .Where(c => c.UserId == userId)
                .Include(c => c.Address)
                .FirstOrDefaultAsync();

            if (addressToEdit.Address != null)
            {
                addressToEdit.Address.Street = model.Street;
                addressToEdit.Address.PostCode = model.PostCode;
                addressToEdit.Address.City = model.City;
                addressToEdit.Address.CountryId = model.Country.Id;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task CreateCustomerAddressAsync(CustomerAddressFormModel model, string userId)
        {
            int? customerId = await GetCustomerIdByUserIdAsync(userId);

            if (customerId != null)
            {
                var customer = await _repository.GetByIdAsync<Customer>(customerId);
                customer.Address = new CustomerAddress()
                {
                    Street = model.Street,
                    PostCode = model.PostCode,
                    City = model.City,
                    CountryId = model.Country.Id
                };

                await _repository.SaveChangesAsync();
            }
        }
    }
}
