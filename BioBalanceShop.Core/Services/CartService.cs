using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository _repository;
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ICookieService _cookieService;

        public CartService(
            IRepository repository,
            IProductService productService,
            IShopService shopService,
            ICookieService cookieService)
        {
            _repository = repository;
            _productService = productService;
            _shopService = shopService;
            _cookieService = cookieService;
        }

        public async Task<CartIndexModel> GetCartProductsInfo(CartCookieModel cart)
        {
            CartIndexModel productsInCart = new CartIndexModel();

            foreach (var item in cart.Items)
            {
                if (!await _productService.ExistsAsync(item.ProductId))
                {
                    cart.Items.RemoveAll(item => item.ProductId == item.ProductId);

                    throw new Exception("Product not found");
                }

                CartIndexProductModel product = await GetProductFromCart(item.ProductId, item.Quantity);
                productsInCart.Items.Add(product);
            }

            return productsInCart;
        }

        public async Task<CartIndexProductModel?> GetProductFromCart(int id, int quantity)
        {
            return await _repository
               .AllReadOnly<Product>()
               .Where(p => p.Id == id)
               .Select(p => new CartIndexProductModel()
               {
                   ProductId = p.Id,
                   Title = p.Title,
                   ImageURL = p.ImageUrl,
                   QuantityToOrder = quantity,
                   QuantityInStock = p.Quantity,
                   Price = p.Price,
                   Currency = new ShopCurrencyServiceModel()
                   {
                       Id = p.Shop.Currency.Id,
                       CurrencySymbol = p.Shop.Currency.Symbol,
                       CurrencyIsSymbolPrefix = p.Shop.Currency.IsSymbolPrefix
                   }
               })
               .FirstOrDefaultAsync();
        }

        public void AddProductToCart(CartCookieModel cart, int productId, int quantity)
        {
            var prodInCart = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (prodInCart != null)
            {
                prodInCart.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItemCookieModel { ProductId = productId, Quantity = quantity });
            }
        }

        public void UpdateProductsInCart(CartUpdateModel updateModel, CartCookieModel cart)
        {
            foreach (var kvp in updateModel.ProductQuantities)
            {
                CartItemCookieModel? itemToUpdate = cart.Items.FirstOrDefault(item => item.ProductId == kvp.Key);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Quantity = kvp.Value;
                }
            }

            foreach (int productId in updateModel.RemovedProductIds)
            {
                cart.Items.RemoveAll(item => item.ProductId == productId);
            }
        }
    }
}
