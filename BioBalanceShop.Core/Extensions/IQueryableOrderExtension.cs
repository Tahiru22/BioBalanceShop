using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQueryableOrderExtension
    {
        public static IQueryable<OrderAllServiceModel> ProjectToOrderServiceModel(this IQueryable<Order> orders)
        {
            return orders
                .Select(o => new OrderAllServiceModel()
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount,
                    Currency = new ShopCurrencyServiceModel()
                    {
                        Id = o.Currency.Id,
                        CurrencyCode = o.Currency.Code,
                        CurrencySymbol = o.Currency.Symbol,
                        CurrencyIsSymbolPrefix = o.Currency.IsSymbolPrefix
                    },
                    OrderItemsCount = o.OrderItems.Sum(o => o.Quantity)
                });
        }
    }
}
