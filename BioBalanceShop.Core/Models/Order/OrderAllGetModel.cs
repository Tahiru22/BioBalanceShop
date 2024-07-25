﻿using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderAllGetModel
    {
        public int OrdersPerPage { get; } = 6;

        public OrderStatus OrderStatus { get; init; }

        [Display(Name = "Search by order number")]
        public string SearchTerm { get; init; } = null!;

        public OrderSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalOrdersCount { get; set; }

        public IEnumerable<OrderStatus> OrderStatuses { get; set; } = null!;

        public IEnumerable<OrderAllServiceModel> Orders { get; set; } = new List<OrderAllServiceModel>();
    }
}
