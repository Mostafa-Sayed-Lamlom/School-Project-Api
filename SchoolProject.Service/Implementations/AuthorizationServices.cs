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

		public async Task<string> EditRoleAsync(string roleName, int id)
		{
			//check role is exist or not
			var role = await _roleManager.FindByIdAsync(id.ToString());
			if (role == null)
				return "notFound";
			//check role name is already Exist or not
			var IsNameExist = await IsRoleExistByName(roleName);
			if (IsNameExist) return "isExist";

			role.Name = roleName;
			var result = await _roleManager.UpdateAsync(role);
			if (result.Succeeded) return "Success";
			var errors = string.Join("-", result.Errors);
			return errors;
		}

		public async Task<string> DeleteRoleAsync(int id)
		{
			//check if id is exist or not
			var role = await _roleManager.FindByIdAsync(id.ToString());
			if (role == null) return "NotFound";
			//check if role is used or not
			var listOfUsersHasRole = await _userManager.GetUsersInRoleAsync(role.Name);
			if (listOfUsersHasRole != null && listOfUsersHasRole.Count() > 0) return "Used";
			//delete role 
			var resultOfDeletedRole = await _roleManager.DeleteAsync(role);
			if (resultOfDeletedRole.Succeeded) return "Success";
			//if deleted faild
			var errors = string.Join("-", resultOfDeletedRole.Errors);
			return errors;
		}
		#endregion
	}
}
