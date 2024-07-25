using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.Order;
using BioBalanceShop.Infrastructure.Data.Enumerations;

namespace BioBalanceShop.Core.Contracts
{
    public interface IAdminOrderService
    {
        Task<AdminOrderQueryServiceModel> AllAsync(
            OrderStatus? orderStatus = null,
            string? searchTerm = null,
            OrderSorting sorting = OrderSorting.OrderDateDescending,
            int currentPage = 1,
            int ordersPerPage = 1);

        Task<AdminOrderDetailsServiceModel?> GetOrderByIdAsync(int id);

        Task<IEnumerable<AdminOrderItemDetailsModel>> GetOrderItemsByOrderIdAsync(int id);

        Task UpdateOrderStatus(int orderId, OrderStatus status);

        Task<bool> ExistsAsync(int id);
    }
}
