using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
