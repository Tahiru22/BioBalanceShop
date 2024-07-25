using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Core.Constants.RoleConstants;

namespace BioBalanceShop.Core.Models.Admin.User
{
    public class AdminUserServiceModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        public string? FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string? LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public IEnumerable<string> Roles { get; set; } = new List<string>();

        public bool IsAdmin => Roles.Contains(AdminRole);
    }
}
