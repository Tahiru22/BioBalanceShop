using BioBalanceShop.Core.Models.Cart;

namespace BioBalanceShop.Core.Contracts
{
    public interface ICartService
    {
        Task<CartIndexModel> GetCartProductsInfo(CartCookieModel cart);
        Task<CartIndexProductModel?> GetProductFromCart(int id, int quantity);

        void AddProductToCart(CartCookieModel cart, int productId, int quantity);
        void UpdateProductsInCart(CartUpdateModel updateModel, CartCookieModel cart);
    }
}
