using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Abstractions
{
	public interface IUserRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
	{

	}
}
