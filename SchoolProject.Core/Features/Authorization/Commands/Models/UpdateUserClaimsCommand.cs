using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
	public class UpdateUserClaimsCommand : ManageUserClaimsResponse, IRequest<Response<string>>
	{
	}
}
