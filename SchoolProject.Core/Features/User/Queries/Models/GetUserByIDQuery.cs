using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queries.Results;

namespace SchoolProject.Core.Features.User.Queries.Models
{
	public class GetUserByIDQuery : IRequest<Response<GetUserByIDResponse>>
	{
		public int Id { get; set; }
	}
}
