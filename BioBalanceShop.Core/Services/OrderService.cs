using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;
        private readonly ICustomerService _customerService;
        private readonly IShopService _shopService;

        public OrderService(
            IRepository repository,
            ICustomerService customerService,
            IShopService shopService)
        {
            _repository = repository;
            _customerService = customerService;
            _shopService = shopService;
        }

        public async Task<OrderQueryServiceModel> AllAsync(OrderStatus? orderStatus = 0, string? searchTerm = null, OrderSorting sorting = OrderSorting.OrderDateDescending, int currentPage = 1, int ordersPerPage = 1, string? userId = null)
        {
            var ordersToShow = _repository.AllReadOnly<Order>()
                .Where(o => o.CustomerId != null && o.Customer.UserId == userId);

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
                .ProjectToOrderServiceModel()
                .ToListAsync();

            int totalOrders = await ordersToShow.CountAsync();

            return new OrderQueryServiceModel()
            {
                Orders = orders,
                TotalOrdersCount = totalOrders
            };
        }

        public async Task<string> CreateOrderAsync(CheckoutFormModel model, CartIndexModel productsInCart, string userId)
        {
            
            Payment payment = new Payment()
            {
                PaymentDate = DateTime.Now,
                PaymentAmount = model.Order.TotalOrderAmount,
                PaymentStatus = PaymentStatus.Success
            };

            OrderRecipient orderRecipient = new OrderRecipient()
            {
                FirstName = model.Customer.FirstName,
                LastName = model.Customer.LastName,
                PhoneNumber = model.Customer.PhoneNumber,
                EmailAddress = model.Customer.Email
            };

            OrderAddress orderAddress = new OrderAddress()
            {
                Street = model.Customer.Street,
                PostCode = model.Customer.PostCode,
                City = model.Customer.City,
                CountryId = model.Customer.Country.Id
            };

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var product in productsInCart.Items)
            {
                orderItems.Add(new OrderItem() {
                    Title = product.Title,
                    ImageUrl = product.ImageURL,
                    Quantity = product.QuantityToOrder,
                    Price = product.Price,
                    CurrencyId = product.Currency.Id
                });
            }

            string orderNumber = GenerateOrderNumber(await GetLastOrderNumberAsync());

            Order order = new Order()
            {
                OrderNumber = orderNumber,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Processing,
                Amount = model.Order.OrderAmount,
                ShippingFee = model.Order.ShippingFee,
                TotalAmount = model.Order.TotalOrderAmount,
                CurrencyId = model.Order.Currency.Id,
                Payment = payment,
                OrderAddress = orderAddress,
                OrderRecipient = orderRecipient,
                OrderItems = orderItems
            };
            
            if (userId != null)
            {
                order.CustomerId = await _customerService.GetCustomerIdByUserIdAsync(userId);
            }
            
            await _repository.AddAsync<Order>(order);
            await _repository.SaveChangesAsync();

            return orderNumber;
        }

        public string GenerateOrderNumber(int lastOrderNumber)
        {
            lastOrderNumber++;
            return "PO" + lastOrderNumber.ToString("D6");
        }

        public async Task<int> GetLastOrderNumberAsync()
        {
            return await _repository.AllReadOnly<Order>()
                .OrderByDescending(o => o.OrderNumber)
                .Select(o => int.Parse(o.OrderNumber.Substring(2)))
                .Take(1)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderDetailsServiceModel?> GetOrderByIdAsync(int id, string userId)
        {
            var order = await _repository
                .AllReadOnly<Order>()
                .Where(o => o.Id == id && o.Customer.UserId == userId)
                .Select(o => new OrderDetailsServiceModel()
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
                    OrderAddress = new OrderAddressDetailsModel()
                    {
                        Id = o.OrderAddress.Id,
                        Street = o.OrderAddress.Street,
                        PostCode = o.OrderAddress.PostCode,
                        City = o.OrderAddress.City,
                        Country = o.OrderAddress.Country.Name
                    },
                    OrderRecipient = new OrderRecipientDetailsModel()
                    {
                        Id = o.OrderRecipient.Id,
                        FirstName = o.OrderRecipient.FirstName,
                        LastName = o.OrderRecipient.LastName,
                        PhoneNumber = o.OrderRecipient.PhoneNumber,
                        EmailAddress = o.OrderRecipient.EmailAddress
                    },
                })
                .FirstOrDefaultAsync();

            order.OrderItems = await GetOrderItemsByOrderId(id);
            return order;
        }

        public async Task<IEnumerable<OrderItemDetailsModel>> GetOrderItemsByOrderId(int id)
        {
            return await _repository.AllReadOnly<Order>()
                .Where(o => o.Id == id)
                .SelectMany(o => o.OrderItems.Select(oi => new OrderItemDetailsModel()
                {
                    Id = oi.Id,
                    Title = oi.Title,
                    ImageUrl = oi.ImageUrl,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }))
                .ToListAsync();
        }

        public async Task<string?> GetUserIdByOrderIdAsync(int id)
        {
            return await _repository
           .AllReadOnly<Order>()
           .Where(o => o.Id == id)
           .Select(o => o.Customer.UserId)
           .FirstOrDefaultAsync();  
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.AllReadOnly<Order>()
                .AnyAsync(o => o.Id == id);
        }
    }
}
