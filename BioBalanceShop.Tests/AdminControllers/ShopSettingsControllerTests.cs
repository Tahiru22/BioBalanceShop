using BioBalanceShop.Areas.Admin.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.ShopSettings;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.AdminControllers
{
    [TestFixture]
    public class ShopSettingsControllerTests
    {
        private Mock<IAdminShopSettingsService> _mockAdminShopSettingsService;
        private Mock<IShopService> _mockShopService;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<ILogger<ShopSettingsController>> _mockLogger;
        private ShopSettingsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockAdminShopSettingsService = new Mock<IAdminShopSettingsService>();
            _mockShopService = new Mock<IShopService>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _mockLogger = new Mock<ILogger<ShopSettingsController>>();

            _controller = new ShopSettingsController(
                _mockAdminShopSettingsService.Object,
                _mockShopService.Object,
                _mockUserManager.Object,
                _mockLogger.Object);
        }


        [Test]
        public async Task Edit_POST_CallsEditShopSettingsAsync_WhenModelStateIsValid()
        {
            var model = new AdminShopSettingsFormModel();

            await _controller.Edit(model);

            _mockAdminShopSettingsService.Verify(x => x.EditShopSettingsAsync(model), Times.Once);
        }

        [Test]
        public async Task Edit_GET_ReturnsInternalServerErrorStatusCode_WhenExceptionOccurs()
        {
            _mockAdminShopSettingsService.Setup(x => x.AllShopSettingsAsync()).ThrowsAsync(new Exception());

            var result = await _controller.Edit();

            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, ((StatusCodeResult)result).StatusCode);
        }

        [Test]
        public async Task Edit_POST_ReturnsInternalServerErrorStatusCode_WhenExceptionOccurs()
        {
            var model = new AdminShopSettingsFormModel();
            _mockAdminShopSettingsService.Setup(x => x.EditShopSettingsAsync(model)).ThrowsAsync(new Exception());

            var result = await _controller.Edit(model);

            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, ((StatusCodeResult)result).StatusCode);
        }
    }
}