using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class AuthorizationServices : IAuthorizationServices
	{
		#region Fields
		private readonly RoleManager<IdentityRole<int>> _roleManager;
		private readonly UserManager<User> _userManager;
		#endregion
		#region Constructors
		public AuthorizationServices(RoleManager<IdentityRole<int>> roleManager,
									UserManager<User> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}
		#endregion
		#region Handle Functions
		public async Task<string> AddRoleAsync(string roleName)
		{
			var identityRole = new IdentityRole<int>();
			identityRole.Name = roleName;
			var result = await _roleManager.CreateAsync(identityRole);
			if (result.Succeeded)
				return "Success";
			return "Failed";
		}

		public async Task<bool> IsRoleExistByName(string roleName)
		{
			return await _roleManager.RoleExistsAsync(roleName);
		}
		#endregion
	}
}
