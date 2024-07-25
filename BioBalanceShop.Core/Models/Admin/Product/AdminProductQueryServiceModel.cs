namespace BioBalanceShop.Core.Models.Admin.Product
{
    public class AdminProductQueryServiceModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<AdminProductServiceModel> Products { get; set; } = new List<AdminProductServiceModel>();
    }
}
