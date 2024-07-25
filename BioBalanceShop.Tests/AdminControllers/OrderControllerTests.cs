using BioBalanceShop.Areas.Admin.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.Order;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.AdminControllers
{
    [TestFixture]
    public class OrderControllerTests
    {
        private Mock<IAdminOrderService> _mockAdminOrderService;
        private Mock<IShopService> _mockShopService;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<ILogger<OrderController>> _mockLogger;
        private OrderController _orderController;

        [SetUp]
        public void Setup()
        {
            _mockAdminOrderService = new Mock<IAdminOrderService>();
            _mockShopService = new Mock<IShopService>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _mockLogger = new Mock<ILogger<OrderController>>();

            _orderController = new OrderController(_mockAdminOrderService.Object, _mockShopService.Object, _mockUserManager.Object, _mockLogger.Object);
        }

        [Test]
        public async Task All_ReturnsViewWithModel_WhenServiceReturnsOrders()
        {
            var model = new AdminOrderAllGetModel();
            var orders = new Order[] { };
            _mockAdminOrderService.Setup(x => x.AllAsync(model.OrderStatus, model.SearchTerm, model.Sorting, model.CurrentPage, model.OrdersPerPage)).ReturnsAsync(new AdminOrderQueryServiceModel());

            var result = await _orderController.All(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(model, result.Model);
        }

        [Test]
        public async Task All_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            var model = new AdminOrderAllGetModel();
            _mockAdminOrderService.Setup(x => x.AllAsync(model.OrderStatus, model.SearchTerm, model.Sorting, model.CurrentPage, model.OrdersPerPage)).ThrowsAsync(new Exception());

            var result = await _orderController.All(model) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Test]
        public async Task EditStatus_ReturnsViewWithModel_WhenOrderExists()
        {
            var id = 1;
            var model = new AdminOrderDetailsServiceModel();
            _mockAdminOrderService.Setup(s => s.ExistsAsync(id)).ReturnsAsync(true);
            _mockAdminOrderService.Setup(s => s.GetOrderByIdAsync(id)).ReturnsAsync(model);

            var result = await _orderController.EditStatus(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(model, result.Model);
        }

        [Test]
        public async Task EditStatus_ReturnsBadRequest_WhenOrderDoesNotExist()
        {
            var id = 1;
            _mockAdminOrderService.Setup(s => s.ExistsAsync(id)).ReturnsAsync(false);

            var result = await _orderController.EditStatus(id) as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task EditStatus_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            var id = 1;
            _mockAdminOrderService.Setup(s => s.ExistsAsync(id)).ReturnsAsync(true);
            _mockAdminOrderService.Setup(s => s.GetOrderByIdAsync(id)).ThrowsAsync(new Exception());

            var result = await _orderController.EditStatus(id) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Test]
        public async Task EditStatusPost_ReturnsRedirectToAction_WhenModelStateIsValid()
        {
            var model = new AdminOrderDetailsServiceModel { Id = 1 };
            _mockAdminOrderService.Setup(s => s.ExistsAsync(model.Id)).ReturnsAsync(true);

            var result = await _orderController.EditStatus(model) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("All", result.ActionName);
        }

        [Test]
        public async Task EditStatusPost_ReturnsBadRequest_WhenOrderDoesNotExist()
        {
            var model = new AdminOrderDetailsServiceModel { Id = 1, Status = OrderStatus.Processing };
            _mockAdminOrderService.Setup(s => s.ExistsAsync(model.Id)).ReturnsAsync(false);

            var result = await _orderController.EditStatus(model) as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task EditStatusPost_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            var model = new AdminOrderDetailsServiceModel { Id = 1, Status = OrderStatus.Processing };
            _mockAdminOrderService.Setup(s => s.ExistsAsync(model.Id)).ReturnsAsync(true);
            _mockAdminOrderService.Setup(s => s.UpdateOrderStatus(model.Id, model.Status)).ThrowsAsync(new Exception());

            var result = await _orderController.EditStatus(model) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
