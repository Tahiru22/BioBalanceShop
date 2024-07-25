namespace BioBalanceShop.Core.Models.Order
{
    public class OrderQueryServiceModel
    {
        public int TotalOrdersCount { get; set; }

        public IEnumerable<OrderAllServiceModel> Orders { get; set; } = new List<OrderAllServiceModel>();
    }
}
