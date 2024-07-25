using BioBalanceShop.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.CookieConstants;

namespace BioBalanceShop.Controllers
{
    public class CookieBannerController : BaseController
    {
        private readonly ICookieService _cookieService;
        private readonly ILogger _logger;

        public CookieBannerController(
            ICookieService cookieService,
            ILogger<CartController> logger)
        {
            _cookieService = cookieService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SetCookieConsent(string consent)
        {
            try
            {
                _cookieService.SetConsentCookie(Response.Cookies, consent);

                if (consent == "rejected")
                {
                    foreach (var cookie in Request.Cookies.Keys)
                    {
                        if (cookie != ConsentCookie)
                        {
                            Response.Cookies.Delete(cookie);
                        }
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CookieBannerConroller/SetCookieConsent/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public bool CheckCookieConsent() 
            => _cookieService.CookieConsentGiven(HttpContext.Request.Cookies[ConsentCookie]);

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UpdateCookieConsent()
        {
            return View();
        }
    }
}
