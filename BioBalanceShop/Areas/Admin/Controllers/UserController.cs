using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.RoleConstants;
using static BioBalanceShop.Infrastructure.Constants.CustomClaims;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminUserAllGetModel model)
        {
            try
            {
                var users = await _userService.AllAsync(
                model.Role,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.UsersPerPage);

                model.TotalUsersCount = users.TotalUsersCount;
                model.Users = users.Users;
                model.Roles = await _userService.GetAllRoles();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/UserController/All/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (await _userManager.FindByIdAsync(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser.Id == id)
                {
                    await _userService.DeleteUserByIdAsync(id);
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                await _userService.DeleteUserByIdAsync(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/UserController/DeleteConfirmed/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AdminUserEditFormModel? model = await _userService.GetUserByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminUserEditFormModel model)
        {
            var modelUser = await _userManager.FindByIdAsync(model.Id);

            if (modelUser == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var currentUser = await _userManager.GetUserAsync(User);

                var modelUserName = $"{modelUser.FirstName} {modelUser.LastName}";
                var modelUserClaims = await _userManager.GetClaimsAsync(modelUser);
                var modelUserFullNameClaim = modelUserClaims.FirstOrDefault(c => c.Value == modelUserName);
                var newFullNameClaim = new Claim(UserFullNameClaim, $"{model.FirstName} {model.LastName}");

                await _userService.EditUserAsync(model);

                await _userManager.ReplaceClaimAsync(modelUser, modelUserFullNameClaim, newFullNameClaim);

                if (currentUser != null && await _userManager.IsInRoleAsync(currentUser, AdminRole) == false)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                if (currentUser.Id == model.Id)
                {
                    await _signInManager.RefreshSignInAsync(currentUser);
                }

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/UserController/Edit/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                AdminUserCreateFormModel model = new AdminUserCreateFormModel();
                model.Roles = await _userService.GetAllRoles();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/UserController/Create/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminUserCreateFormModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Roles = await _userService.GetAllRoles();
                    return View(model);
                }

                await _userService.CreateUserAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/UserController/Create/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
