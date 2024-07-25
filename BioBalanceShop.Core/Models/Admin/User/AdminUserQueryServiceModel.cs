namespace BioBalanceShop.Core.Models.Admin.User
{
    public class AdminUserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }

        public IEnumerable<AdminUserServiceModel> Users { get; set; } = new List<AdminUserServiceModel>();
    }
}
