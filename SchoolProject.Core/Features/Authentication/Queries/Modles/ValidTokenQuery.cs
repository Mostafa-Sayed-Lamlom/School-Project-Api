using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Queries.Modles
{
	public class ValidTokenQuery : IRequest<Response<string>>
	{
		public string Token { get; set; }
	}
}
