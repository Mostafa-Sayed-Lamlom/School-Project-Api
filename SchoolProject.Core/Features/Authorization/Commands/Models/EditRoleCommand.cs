using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
	public class EditRoleCommand : IRequest<Response<string>>
	{
		public int id { get; set; }
		public string roleName { get; set; }
	}
}
