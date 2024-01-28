using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.User.Commands.Models
{
	public class ChangeUserPasswordCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmNewPassword { get; set; }

	}
}
