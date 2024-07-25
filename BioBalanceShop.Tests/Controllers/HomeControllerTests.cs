using BioBalanceShop.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _homeController;
        private Mock<ILogger<HomeController>> _loggerMock;
        private Mock<IProductService> _productServiceMock;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _productServiceMock = new Mock<IProductService>();
            _homeController = new HomeController(_loggerMock.Object, _productServiceMock.Object);
        }

        [Test]
        public async Task Index_ReturnsView_WithModel()
        {
            var products = new List<HomeIndexProductModel>();
            _productServiceMock.Setup(p => p.GetLastFiveProductsAsync()).ReturnsAsync(products);

            var result = await _homeController.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(products, viewResult.Model);
        }

        [Test]
        public async Task Index_ReturnsBadRequest_WhenModelIsNull()
        {
            _productServiceMock.Setup(p => p.GetLastFiveProductsAsync()).ReturnsAsync((IEnumerable<HomeIndexProductModel>)null);

            var result = await _homeController.Index();

            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [TestCase(400)]
        [TestCase(401)]
        [TestCase(404)]
        [TestCase(500)]
        public void Error_ReturnsCorrectView(int statusCode)
        {
            var result = _homeController.Error(statusCode);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual($"Error{statusCode}", viewResult.ViewName);
        }

        [Test]
        public void Error_ReturnsDefaultView_ForUnhandledStatusCode()
        {
            var statusCode = 403;

            var result = _homeController.Error(statusCode);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsNull(viewResult.ViewName);
        }
    }
}
