using BioBalanceShop.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Admin.User
{
    public class AdminUserAllGetModel
    {
        public int UsersPerPage { get; } = 6;

        public string Role { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public UserSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalUsersCount { get; set; }

        public IEnumerable<string> Roles { get; set; } = null!;

        public IEnumerable<AdminUserServiceModel> Users { get; set; } = new List<AdminUserServiceModel>();
    }
}
