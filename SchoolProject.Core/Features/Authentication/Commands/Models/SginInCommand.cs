using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
	public class SginInCommand : IRequest<Response<JwtAuthResult>>
	{
		//public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
