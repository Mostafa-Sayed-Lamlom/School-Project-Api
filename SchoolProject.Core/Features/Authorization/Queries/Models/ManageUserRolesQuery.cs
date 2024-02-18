using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
	public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResponse>>
	{
		public int userId { get; set; }
	}
}
