using BioBalanceShop.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Tests.AdminControllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Dashboard_Returns_ViewResult()
        {
            var controller = new HomeController();

            var result = controller.Dashboard() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
