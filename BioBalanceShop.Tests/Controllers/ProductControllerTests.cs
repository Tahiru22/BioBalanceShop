using BioBalanceShop.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Extensions;
using BioBalanceShop.Core.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Moq;


namespace BioBalanceShop.Tests.Controllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ProductController _productController;
        private Mock<IProductService> _mockProductService;
        private Mock<IShopService> _mockShopService;
        private Mock<ILogger<ProductController>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _mockShopService = new Mock<IShopService>();
            _mockLogger = new Mock<ILogger<ProductController>>();

            _productController = new ProductController(
                _mockProductService.Object,
                _mockShopService.Object,
                _mockLogger.Object);

            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            _productController.TempData = tempData;

            _mockProductService.Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProductDetailsServiceModel { Title = "Test Product" });
        }

        [Test]
        public async Task All_ReturnsViewResult_WithValidModel()
        {
            var model = new ProductAllServiceModel();
            _mockProductService.Setup(x => x.AllAsync(model.Category, model.SearchTerm, model.Sorting, model.CurrentPage, model.ProductsPerPage)).ReturnsAsync(new ProductQueryServiceModel());

            var result = await _productController.All(model);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<ProductAllServiceModel>(viewResult.Model);
        }

        [Test]
        public async Task All_ReturnsStatusCode500_WhenExceptionThrown()
        {
            var model = new ProductAllServiceModel();
            _mockProductService.Setup(x => x.AllAsync(model.Category, model.SearchTerm, model.Sorting, model.CurrentPage, model.ProductsPerPage)).ThrowsAsync(new Exception());

            var result = await _productController.All(model);

            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task Details_ReturnsBadRequest_WhenModelIsNull()
        {
            int id = 1;
            string productInfo = "info";
            _mockProductService.Setup(x => x.GetProductByIdAsync(id)).ReturnsAsync((ProductDetailsServiceModel)null);

            var result = await _productController.Details(id, productInfo);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task Details_ReturnsBadRequest_WhenProductInfoDoesNotMatch()
        {
            int id = 1;
            string productInfo = "info";
            var model = new ProductDetailsServiceModel { Id = id, Title = "Product Title" };
            _mockProductService.Setup(x => x.GetProductByIdAsync(id)).ReturnsAsync(model);

            var result = await _productController.Details(id, productInfo);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task Details_SetsViewBagSiteMessage_WhenTempDataContainsMessage()
        {
            int productId = 1;
            var productInfo = "Test-Product";
            var product = new ProductDetailsServiceModel { Title = "Test Product" };
            string productInfoFromExtension = product.GetProductInfo();
            _productController.TempData["AddedToCartMessage"] = "Added to cart successfully";

            var result = await _productController.Details(productId, productInfo);

            Assert.IsNotNull(_productController.ViewBag.SiteMessage);
            Assert.AreEqual("Added to cart successfully", _productController.ViewBag.SiteMessage);
        }
    }
}
