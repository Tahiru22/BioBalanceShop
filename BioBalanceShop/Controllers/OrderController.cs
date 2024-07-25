using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BioBalanceShop.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public OrderController(
            IOrderService orderService,
            UserManager<ApplicationUser> userManager,
            ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders([FromQuery] OrderAllGetModel model)
        {
            try
            {
                var orders = await _orderService.AllAsync(
                model.OrderStatus,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.OrdersPerPage,
                User.Id());

                model.TotalOrdersCount = orders.TotalOrdersCount;
                model.Orders = orders.Orders;
                model.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OrderConroller/MyOrders/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await _orderService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (await _orderService.GetUserIdByOrderIdAsync(id) != User.Id())
            {
                return Unauthorized();
            }

            var model = await _orderService.GetOrderByIdAsync(id, User.Id());
            
            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
