using BioBalanceShop.Attributes;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.CookieConstants;
using BioBalanceShop.Core.Extensions;

namespace BioBalanceShop.Controllers
{
    public class CartController : BaseController
    {
        private readonly IShopService _shopService;
        private readonly ICookieService _cookieService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly ILogger _logger;

        public CartController(
            IShopService shopService,
            ICookieService cookieService,
            ICartService cartService,
            IProductService productService,
            ILogger<CartController> logger)
        {
            _shopService = shopService;
            _cookieService = cookieService;
            _cartService = cartService;
            _productService = productService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public async Task<IActionResult> AddToCart(int productId, int quantity, string productInfo)
        {
            var model = await _productService.GetProductByIdAsync(productId);

            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                if (productInfo != model.GetProductInfo())
                {
                    return BadRequest();
                }
            }

            try
            {
                CartCookieModel cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);

                _cartService.AddProductToCart(cart, productId, quantity);
                _cookieService.SetCartCookie(Response.Cookies, cart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartConroller/AddToCart/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (quantity == 1)
                {
                    TempData["AddedToCartMessage"] = $"{quantity} product successfully added to cart";
                }
                else
                {
                    TempData["AddedToCartMessage"] = $"{quantity} products successfully added to cart";
                }

                return RedirectToAction("Details", "Product", new { id = productId, productInfo = model.GetProductInfo() });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                CartCookieModel cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);
                CartIndexModel productsInCart = await _cartService.GetCartProductsInfo(cart);

                productsInCart.TotalPrice = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
                var currency = await _shopService.GetShopCurrency();

                if (currency != null)
                {
                    productsInCart.CurrencySymbol = currency.CurrencySymbol;
                    productsInCart.CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix;
                }

                return View(productsInCart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartConroller/Index/Get");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public IActionResult UpdateCart(CartUpdateModel updateModel)
        {
            try
            {
                CartCookieModel cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);

                _cartService.UpdateProductsInCart(updateModel, cart);
                _cookieService.SetCartCookie(Response.Cookies, cart);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartConroller/UpdateCart/Post");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}