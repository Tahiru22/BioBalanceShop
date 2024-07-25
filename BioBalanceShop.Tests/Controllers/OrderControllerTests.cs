using BioBalanceShop.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;

namespace BioBalanceShop.Tests.Controllers
{
    [TestFixture]
    public class OrderControllerTests
    {
        private OrderController _orderController;
        private Mock<IOrderService> _mockOrderService;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<ILogger<OrderController>> _mockLogger;


        [SetUp]
        public void Setup()
        {
            _mockOrderService = new Mock<IOrderService>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _mockLogger = new Mock<ILogger<OrderController>>();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "testuser"),
                new Claim(ClaimTypes.NameIdentifier, "userid")
            };

            var identity = new ClaimsIdentity(claims, "TestAuthentication");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            _orderController = new OrderController(_mockOrderService.Object, _mockUserManager.Object, _mockLogger.Object)
            {
                ControllerContext = controllerContext
            };
        }


        [Test]
        public async Task MyOrders_Returns_View_With_Model()
        {
            var model = new OrderAllGetModel();
            var orders = new Order[] { };
            _mockOrderService.Setup(x => x.AllAsync(model.OrderStatus, model.SearchTerm, model.Sorting, model.CurrentPage, model.OrdersPerPage, It.IsAny<string>())).ReturnsAsync(new OrderQueryServiceModel());

            var result = await _orderController.MyOrders(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(model, result.Model);
        }

        [Test]
        public async Task MyOrders_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            var model = new OrderAllGetModel();
            _mockOrderService.Setup(x => x.AllAsync(model.OrderStatus, model.SearchTerm, model.Sorting, model.CurrentPage, model.OrdersPerPage, It.IsAny<string>())).ThrowsAsync(new Exception());

            var result = await _orderController.MyOrders(model) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Test]
        public async Task Details_Returns_BadRequest_When_Order_Does_Not_Exist()
        {
            var orderId = 1;
            _mockOrderService.Setup(x => x.ExistsAsync(orderId)).ReturnsAsync(false);

            var result = await _orderController.Details(orderId) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public async Task Details_Returns_Unauthorized_When_User_Not_Authorized()
        {
            var orderId = 1;
            var userId = "userId";
            _mockOrderService.Setup(x => x.ExistsAsync(orderId)).ReturnsAsync(true);
            _mockOrderService.Setup(x => x.GetUserIdByOrderIdAsync(orderId)).ReturnsAsync("anotherUserId");

            var result = await _orderController.Details(orderId) as UnauthorizedResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status401Unauthorized, result.StatusCode);
        }
    }
}
