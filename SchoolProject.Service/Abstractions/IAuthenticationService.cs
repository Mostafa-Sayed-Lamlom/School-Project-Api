using SchoolProject.Data.Identity;

namespace SchoolProject.Service.Abstractions
{
	public interface IAuthenticationService
	{
		public Task<string> GenerateJWTTokenAsync(User user);
	}
}
