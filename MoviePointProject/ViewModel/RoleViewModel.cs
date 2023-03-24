using Microsoft.AspNetCore.Identity;

namespace MoviePoint.ViewModel
{
    public class RoleViewModel
    {
		public string RoleID { get; set; }
		public string UserID { get; set; }

		public string UserName { get; set; }

		public string RoleName { get; set; }

		public List<IdentityUser> Users { get; set; }

		public List<IdentityRole> Roles { get; set; }
	}
}
