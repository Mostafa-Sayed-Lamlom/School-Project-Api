using SchoolProject.Data.Identity;

namespace SchoolProject.Service.AuthServices.Interfaces
{
	public interface ICurrentUserServices
	{
		public Task<User> GetUserAsync();
		public int GetUserId();
		public Task<List<string>> GetCurrentUserRolesAsync();
	}
}
