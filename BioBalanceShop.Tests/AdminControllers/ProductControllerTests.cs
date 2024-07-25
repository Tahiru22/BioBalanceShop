using BioBalanceShop.Areas.Admin.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.AdminControllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ProductController _productController;
        private Mock<IProductService> _productServiceMock;
        private Mock<IAdminProductService> _adminProductServiceMock;
        private Mock<IShopService> _shopServiceMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<ILogger<ProductController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _productServiceMock = new Mock<IProductService>();
            _adminProductServiceMock = new Mock<IAdminProductService>();
            _shopServiceMock = new Mock<IShopService>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _loggerMock = new Mock<ILogger<ProductController>>();

            _productController = new ProductController(
                _productServiceMock.Object,
                _adminProductServiceMock.Object,
                _shopServiceMock.Object,
                _userManagerMock.Object,
                _loggerMock.Object);
        }

        [Test]
        public async Task All_ReturnsAViewResult_WithAListOfProducts()
        {
            var model = new AdminProductAllServiceModel();
            _adminProductServiceMock.Setup(x => x.AllAsync(model.Category, model.SearchTerm, model.Sorting, model.CurrentPage, model.ProductsPerPage)).ReturnsAsync(new AdminProductQueryServiceModel());

            var result = await _productController.All(model);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<AdminProductAllServiceModel>(viewResult.Model);
        }

        [Test]
        public async Task All_ReturnsStatusCode500_WhenExceptionThrown()
        {
            var model = new AdminProductAllServiceModel();
            _adminProductServiceMock.Setup(x => x.AllAsync(model.Category, model.SearchTerm, model.Sorting, model.CurrentPage, model.ProductsPerPage)).ThrowsAsync(new Exception());

            var result = await _productController.All(model);

            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task DeleteConfirmed_ProductExists_ReturnsRedirectToActionResult()
        {
            int id = 1;
            _productServiceMock.Setup(service => service.ExistsAsync(id)).ReturnsAsync(true);

            var result = await _productController.DeleteConfirmed(id) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("All", result.ActionName);
        }

        [Test]
        public async Task Edit_Get_ProductExists_ReturnsViewResultWithModel()
        {
            var categories = new List<CategoryAllServiceModel> { new CategoryAllServiceModel { Name = "Category1" }, new CategoryAllServiceModel { Name = "Category2" } };
            var currency = new ShopCurrencyServiceModel();
            int id = 1;
            var product = new AdminProductEditFormModel();
            _productServiceMock.Setup(service => service.ExistsAsync(id)).ReturnsAsync(true);
            _adminProductServiceMock.Setup(service => service.GetProductByIdAsync(id)).ReturnsAsync(product);
            _productServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);
            _shopServiceMock.Setup(service => service.GetShopCurrency()).ReturnsAsync(new ShopCurrencyServiceModel());

            var result = await _productController.Edit(id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<AdminProductEditFormModel>(result.Model);
            Assert.AreEqual(product, result.Model);
        }

        [Test]
        public async Task Create_Get_ReturnsViewResultWithModel()
        {
            var categories = new List<CategoryAllServiceModel> { new CategoryAllServiceModel { Name = "Category1" }, new CategoryAllServiceModel { Name = "Category2" } };
            var currency = new ShopCurrencyServiceModel { Id = 1, CurrencyCode = "USD", CurrencyIsSymbolPrefix = true, CurrencySymbol = "$" };
            _productServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);
            _shopServiceMock.Setup(service => service.GetShopCurrency()).ReturnsAsync(currency);

            var result = await _productController.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<AdminProductCreateFormModel>(result.Model);
            var model = result.Model as AdminProductCreateFormModel;
            CollectionAssert.AreEquivalent(categories.Select(c => c.Name), model.Categories.Select(c => c.Name));
            Assert.AreEqual(currency.Id, model.Currency.Id);
            Assert.AreEqual(currency.CurrencyCode, model.Currency.CurrencyCode);
            Assert.AreEqual(currency.CurrencyIsSymbolPrefix, model.Currency.CurrencyIsSymbolPrefix);
            Assert.AreEqual(currency.CurrencySymbol, model.Currency.CurrencySymbol);
        }
    }
}
