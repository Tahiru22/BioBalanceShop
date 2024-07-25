namespace BioBalanceShop.Core.Models.Cart
{
    public class CartIndexModel
    {
        public List<CartIndexProductModel> Items { get; set; } = new List<CartIndexProductModel>();

        public decimal TotalPrice { get; set; }

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
