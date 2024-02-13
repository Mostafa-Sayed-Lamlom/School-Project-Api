using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories
{
	public class UserRefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IUserRefreshTokenRepository
	{
		#region Fields
		private readonly DbSet<UserRefreshToken> _userRefreshToken;
		#endregion

		#region Constructors
		public UserRefreshTokenRepository(AppDbContext DbContext) : base(DbContext)
		{
			_userRefreshToken = DbContext.UserRefreshToken;
		}
		#endregion

		#region Haundle Functions
		#endregion
	}
}
