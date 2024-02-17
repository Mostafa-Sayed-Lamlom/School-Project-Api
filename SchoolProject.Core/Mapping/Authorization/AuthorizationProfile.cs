using AutoMapper;

namespace SchoolProject.Core.Mapping.Authorization
{
	public partial class AuthorizationProfile : Profile
	{
		public AuthorizationProfile()
		{
			GetRolesListMapping();
		}
	}
}
