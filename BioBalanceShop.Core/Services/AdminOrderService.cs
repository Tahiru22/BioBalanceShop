using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.Order;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class AdminOrderService : IAdminOrderService
    {
        private readonly IRepository _repository;
        private readonly ICustomerService _customerService;
        private readonly IShopService _shopService;

        public AdminOrderService(
            IRepository repository,
            ICustomerService customerService,
            IShopService shopService)
        {
            _repository = repository;
            _customerService = customerService;
            _shopService = shopService;
        }

        public async Task<AdminOrderQueryServiceModel> AllAsync(OrderStatus? orderStatus = 0, string? searchTerm = null, OrderSorting sorting = OrderSorting.OrderDateDescending, int currentPage = 1, int ordersPerPage = 1)
        {
            var ordersToShow = _repository.AllReadOnly<Order>();

            if (orderStatus != 0)
            {
                ordersToShow = ordersToShow
                    .Where(o => o.Status == orderStatus);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                ordersToShow = ordersToShow
                    .Where(o => o.OrderNumber.ToLower().Contains(normalizedSearchTerm));
            }

            ordersToShow = sorting switch
            {
                OrderSorting.OrderDateDescending => ordersToShow
                    .OrderByDescending(o => o.OrderDate),
                OrderSorting.OrderDateAscending => ordersToShow
                .OrderBy(o => o.OrderDate),
                OrderSorting.AmountAscending => ordersToShow
                    .OrderBy(o => o.TotalAmount),
                OrderSorting.AmountDescending => ordersToShow
                    .OrderByDescending(o => o.TotalAmount),
                _ => ordersToShow
                    .OrderByDescending(o => o.OrderDate)
            };

            var orders = await ordersToShow
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ProjectToAdminOrderServiceModel()
                .ToListAsync();

            int totalOrders = await ordersToShow.CountAsync();

            return new AdminOrderQueryServiceModel()
            {
                Orders = orders,
                TotalOrdersCount = totalOrders
            };
        }

        public async Task<AdminOrderDetailsServiceModel?> GetOrderByIdAsync(int id)
        {
            var order = await _repository
                .AllReadOnly<Order>()
                .Where(o => o.Id == id)
                .Select(o => new AdminOrderDetailsServiceModel()
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    Amount = o.Amount,
                    ShippingFee = o.ShippingFee,
                    TotalAmount = o.TotalAmount,
                    Currency = new ShopCurrencyServiceModel()
                    {
                        Id = o.Currency.Id,
                        CurrencyCode = o.Currency.Code,
                        CurrencySymbol = o.Currency.Symbol,
                        CurrencyIsSymbolPrefix = o.Currency.IsSymbolPrefix
                    },
                    OrderAddress = new AdminOrderAddressDetailsModel()
                    {
                        Id = o.OrderAddress.Id,
                        Street = o.OrderAddress.Street,
                        PostCode = o.OrderAddress.PostCode,
                        City = o.OrderAddress.City,
                        Country = o.OrderAddress.Country.Name
                    },
                    OrderRecipient = new AdminOrderRecipientDetailsModel()
                    {
                        Id = o.OrderRecipient.Id,
                        FirstName = o.OrderRecipient.FirstName,
                        LastName = o.OrderRecipient.LastName,
                        PhoneNumber = o.OrderRecipient.PhoneNumber,
                        EmailAddress = o.OrderRecipient.EmailAddress
                    },
                })
                .FirstOrDefaultAsync();

            order.OrderItems = await GetOrderItemsByOrderIdAsync(id);
            return order;
        }

        public async Task<IEnumerable<AdminOrderItemDetailsModel>> GetOrderItemsByOrderIdAsync(int id)
        {
            return await _repository.AllReadOnly<Order>()
               .Where(o => o.Id == id)
               .SelectMany(o => o.OrderItems.Select(oi => new AdminOrderItemDetailsModel()
               {
                   Id = oi.Id,
                   Title = oi.Title,
                   ImageUrl = oi.ImageUrl,
                   Quantity = oi.Quantity,
                   Price = oi.Price
               }))
               .ToListAsync();
        }

        public async Task UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _repository.GetByIdAsync<Order>(orderId);

            order.Status = status;
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.AllReadOnly<Order>()
                .AnyAsync(o => o.Id == id);
        }
    }
}
