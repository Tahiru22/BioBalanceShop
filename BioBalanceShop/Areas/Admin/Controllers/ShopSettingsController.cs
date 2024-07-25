using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.ShopSettings;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class ShopSettingsController : AdminBaseController
    {
        private readonly IAdminShopSettingsService _adminShopSettingsService;
        private readonly IShopService _shopService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ShopSettingsController> _logger;

        public ShopSettingsController(
            IAdminShopSettingsService adminShopSettingsService,
            IShopService shopService,
            UserManager<ApplicationUser> userManager,
            ILogger<ShopSettingsController> logger)
        {
            _adminShopSettingsService = adminShopSettingsService;
            _shopService = shopService;
            _userManager = userManager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            try
            {
                var model = await _adminShopSettingsService.AllShopSettingsAsync();
                model.Currencies = await _adminShopSettingsService.AllCurrenciesAsync();

                string? updatedShopSettingsMessage = TempData["ShopSettingsUpdatedMessage"] as string;

                if (!string.IsNullOrEmpty(updatedShopSettingsMessage))
                {
                    ViewBag.SiteMessage = updatedShopSettingsMessage;
                }

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ShopSettingsController/Edit/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AdminShopSettingsFormModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Currencies = await _adminShopSettingsService.AllCurrenciesAsync();

                    return View(model);
                }

                await _adminShopSettingsService.EditShopSettingsAsync(model);

                TempData["ShopSettingsUpdatedMessage"] = "Successfully updated shop settings";

                return RedirectToAction(nameof(Edit));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ShopSettingsController/Edit/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
