using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.Order;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IAdminOrderService _adminOrderService;
        private readonly IShopService _shopService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<OrderController> _logger;

        public OrderController(
            IAdminOrderService adminOrderService,
            IShopService shopService,
            UserManager<ApplicationUser> userManager,
            ILogger<OrderController> logger)
        {
            _adminOrderService = adminOrderService;
            _shopService = shopService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminOrderAllGetModel model)
        {
            try
            {
                var orders = await _adminOrderService.AllAsync(
                model.OrderStatus,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.OrdersPerPage);

                model.TotalOrdersCount = orders.TotalOrdersCount;
                model.Orders = orders.Orders;
                model.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/OrderController/EditStatus/Post/All/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditStatus(int id)
        {
            if (!await _adminOrderService.ExistsAsync(id))
            {
                return BadRequest();
            }

            try
            {
                var model = await _adminOrderService.GetOrderByIdAsync(id);
                model.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/OrderController/EditStatus/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStatus(AdminOrderDetailsServiceModel model)
        {
            if (!await _adminOrderService.ExistsAsync(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _adminOrderService.UpdateOrderStatus(model.Id, model.Status);

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/OrderController/EditStatus/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
