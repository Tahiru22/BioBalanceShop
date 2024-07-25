using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Infrastructure.Data.Enumerations;

namespace BioBalanceShop.Core.Contracts
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(CheckoutFormModel model, CartIndexModel productsInCart, string userId);

        string GenerateOrderNumber(int lastOrderNumber);

        Task<int> GetLastOrderNumberAsync();

        Task<OrderQueryServiceModel> AllAsync(
            OrderStatus? orderStatus = null,
            string? searchTerm = null,
            OrderSorting sorting = OrderSorting.OrderDateDescending,
            int currentPage = 1,
            int ordersPerPage = 1, 
            string? userId = null);

        Task<OrderDetailsServiceModel?> GetOrderByIdAsync(int id, string userId);

        Task<IEnumerable<OrderItemDetailsModel>> GetOrderItemsByOrderId(int id);

        Task<string?> GetUserIdByOrderIdAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
