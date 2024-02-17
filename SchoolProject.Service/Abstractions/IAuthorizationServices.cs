namespace SchoolProject.Service.Abstractions
{
	public interface IAuthorizationServices
	{
		public Task<string> AddRoleAsync(string roleName);
		public Task<bool> IsRoleExistByName(string roleName);
		public Task<string> EditRoleAsync(string roleName, int id);
		public Task<string> DeleteRoleAsync(int id);
	}
}
