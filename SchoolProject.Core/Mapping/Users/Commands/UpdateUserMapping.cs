using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Data.Identity;

namespace SchoolProject.Core.Mapping.Users
{
	public partial class UserProfile
	{
		public void UpdateUserMapping()
		{
			CreateMap<EditUserCommand, User>();
		}
	}
}
