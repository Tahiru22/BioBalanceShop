using BioBalanceShop.Controllers;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.Controllers
{
    [TestFixture]
    public class CartControllerTests
    {
        private CartController _controller;
        private Mock<IShopService> _shopServiceMock;
        private Mock<ICookieService> _cookieServiceMock;
        private Mock<ICartService> _cartServiceMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<ILogger<CartController>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _shopServiceMock = new Mock<IShopService>();
            _cookieServiceMock = new Mock<ICookieService>();
            _cartServiceMock = new Mock<ICartService>();
            _productServiceMock = new Mock<IProductService>();
            _loggerMock = new Mock<ILogger<CartController>>();

            _controller = new CartController(
                _shopServiceMock.Object,
                _cookieServiceMock.Object,
                _cartServiceMock.Object,
                _productServiceMock.Object,
                _loggerMock.Object
            );
        }

        
        [Test]
        public async Task AddToCart_InvalidProduct_ReturnsBadRequest()
        {
            _productServiceMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync((ProductDetailsServiceModel)null);

            var result = await _controller.AddToCart(0, 1, "info") as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AddToCart_ProductInfoMismatch_ReturnsBadRequest()
        {
            var model = new ProductDetailsServiceModel { Id = 1 };
            _productServiceMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(model);

            var result = await _controller.AddToCart(1, 1, "wrong info") as BadRequestResult;

            Assert.IsNotNull(result);
        }
    }
}
