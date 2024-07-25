using BioBalanceShop.Controllers;
using BioBalanceShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BioBalanceShop.Tests.Controllers
{
    [TestFixture]
    public class CookieBannerControllerTests
    {
        private Mock<ICookieService> _cookieServiceMock;
        private Mock<ILogger<CartController>> _loggerMock;
        private CookieBannerController _controller;

        [SetUp]
        public void Setup()
        {
            _cookieServiceMock = new Mock<ICookieService>();
            _loggerMock = new Mock<ILogger<CartController>>();
            _controller = new CookieBannerController(_cookieServiceMock.Object, _loggerMock.Object);
        }


        [Test]
        public void UpdateCookieConsent_ReturnViewResult()
        {
            var result = _controller.UpdateCookieConsent() as ViewResult;

            Assert.NotNull(result);
        }
    }
}
