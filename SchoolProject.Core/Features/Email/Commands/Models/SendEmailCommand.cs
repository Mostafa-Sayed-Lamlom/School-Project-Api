using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Email.Commands.Models
{
	public class SendEmailCommand : IRequest<Response<string>>
	{
		public string email { get; set; }
		public string message { get; set; }
	}
}
