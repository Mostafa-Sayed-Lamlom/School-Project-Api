using MediatR;
using SchoolProject.Core.Features.User.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.User.Queries.Models
{
	public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserLPaginationResponse>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
