using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Mapping.Authorization
{
	public partial class AuthorizationProfile
	{
		public void GetRolesListMapping()
		{
			CreateMap<IdentityRole<int>, GetRoleResponse>();
		}
	}
}
