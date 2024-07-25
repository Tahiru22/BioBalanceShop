namespace BioBalanceShop.Core.Models.Cart
{
    public class CartUpdateModel
    {
        public Dictionary<int, int> ProductQuantities { get; set; } = new Dictionary<int, int>();
        public List<int> RemovedProductIds { get; set; } = new List<int>();
    }
}
