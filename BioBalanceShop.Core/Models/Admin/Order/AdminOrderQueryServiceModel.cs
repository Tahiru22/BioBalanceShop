namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderQueryServiceModel
    {
        public int TotalOrdersCount { get; set; }

        public IEnumerable<AdminOrderAllServiceModel> Orders { get; set; } = new List<AdminOrderAllServiceModel>();
    }
}
