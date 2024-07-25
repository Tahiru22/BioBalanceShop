using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
