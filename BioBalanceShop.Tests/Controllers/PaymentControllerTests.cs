using BioBalanceShop.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.Controllers
{
    [TestFixture]
    public class PaymentControllerTests
    {
        private PaymentController _controller;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IShopService> _shopServiceMock;
        private Mock<IPaymentService> _paymentServiceMock;
        private Mock<ICartService> _cartServiceMock;
        private Mock<ICookieService> _cookieServiceMock;
        private Mock<IOrderService> _orderServiceMock;
        private Mock<ILogger<PaymentController>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _configurationMock = new Mock<IConfiguration>();
            _productServiceMock = new Mock<IProductService>();
            _shopServiceMock = new Mock<IShopService>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _cartServiceMock = new Mock<ICartService>();
            _cookieServiceMock = new Mock<ICookieService>();
            _orderServiceMock = new Mock<IOrderService>();
            _loggerMock = new Mock<ILogger<PaymentController>>();

            _controller = new PaymentController(
                _configurationMock.Object,
                _productServiceMock.Object,
                _shopServiceMock.Object,
                _paymentServiceMock.Object,
                _cartServiceMock.Object,
                _cookieServiceMock.Object,
                _orderServiceMock.Object,
                _loggerMock.Object);
        }


        [Test]
        public async Task Charge_WithNullStripeToken_ReturnsBadRequest()
        {
            string stripeToken = null;
            var controller = new PaymentController(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                _loggerMock.Object);

            var result = await controller.Charge(stripeToken);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Error", redirectToActionResult.ActionName);
            Assert.AreEqual("Home", redirectToActionResult.ControllerName);
            Assert.AreEqual(StatusCodes.Status400BadRequest, redirectToActionResult.RouteValues["StatusCode"]);
        }

        [Test]
        public async Task Checkout_ExceptionThrown_ReturnsInternalServerError()
        {
            var validModel = new CheckoutFormModel(); // Assuming a valid model
            _cookieServiceMock.Setup(c => c.SaveOrderInfoInCookie(It.IsAny<IResponseCookies>(), It.IsAny<CheckoutFormModel>())).Throws(new Exception());
            var controller = new PaymentController(
                null,
                null,
                null,
                null,
                null,
                _cookieServiceMock.Object,
                null,
                _loggerMock.Object);

            var result = await controller.Checkout(validModel);

            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
    }
}
