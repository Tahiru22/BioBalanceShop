// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Customer;
using BioBalanceShop.Core.Models.Shared;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.RoleConstants;
using static BioBalanceShop.Infrastructure.Constants.CustomClaims;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ApplicationUserData;

namespace BioBalanceShop.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICustomerService _customerService;
        private readonly IShopService _shopService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICustomerService customerService,
            IShopService shopService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerService = customerService;
            _shopService = shopService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
            public string LastName { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Street")]
            public string Street { get; set; }

            [Display(Name = "Post code")]
            public string PostCode { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }

            [Display(Name = "Country")]
            public CustomerAddressCountryFormModel Country { get; set; }

            public IList<ShopCountryServiceModel> Countries { get; set; } = new List<ShopCountryServiceModel>();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var address = new CustomerAddressFormModel()
            {
                Country = new CustomerAddressCountryFormModel()
            };

            if (await _customerService.CustomerAddressExists(user.Id))
            {
                address = await _customerService.GetCustomerAddressFormModel(user.Id);
            }

            var countries = await _shopService.AllCountriesAsync();

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Street = address.Street,
                PostCode = address.PostCode,
                City = address.City,
                Country = address.Country,
                Countries = new List<ShopCountryServiceModel>(countries)
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;

            var userName = User.FindFirstValue(UserFullNameClaim);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var currentUserFullNameClaim = userClaims.FirstOrDefault(c => c.Value == userName);
            var newUserFullNameClaim = new Claim(UserFullNameClaim, $"{user.FirstName} {user.LastName}");

            if (string.IsNullOrEmpty(userName))
            {
                await _userManager.AddClaimAsync(user, newUserFullNameClaim);
            }
            else
            {
                await _userManager.ReplaceClaimAsync(user, currentUserFullNameClaim, newUserFullNameClaim);
            }

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if ((this.User?.Identity?.IsAuthenticated ?? false) && (this.User.IsInRole(CustomerRole)))
            {
                var address = new CustomerAddressFormModel()
                {
                    Street = Input.Street,
                    PostCode = Input.PostCode,
                    City = Input.City,
                    Country = new CustomerAddressCountryFormModel()
                    {
                        Id = Input.Country.Id,
                        Name = Input.Country.Name
                    }
                };

                if (await _customerService.CustomerAddressExists(user.Id))
                {
                    await _customerService.EditCustomerAddressAsync(address, user.Id);
                }
                else
                {
                    await _customerService.CreateCustomerAddressAsync(address, user.Id);
                }

            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
