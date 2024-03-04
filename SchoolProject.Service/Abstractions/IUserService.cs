using SchoolProject.Data.Identity;

namespace SchoolProject.Service.Abstractions
{
	public interface IUserService
	{
		public Task<string> AddUserAsync(User user, string password);
	}
}
