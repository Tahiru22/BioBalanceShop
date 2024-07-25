using BioBalanceShop.Core.Models._Base;

namespace BioBalanceShop.Core.Models.Cart
{
    public class CartIndexProductModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageURL { get; set; } = string.Empty;

        public int QuantityToOrder { get; set; }

        public int QuantityInStock { get; set; }

        public decimal Price { get; set; }

        public ShopCurrencyServiceModel Currency { get; set; } = null!;
    }
}
