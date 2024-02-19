using MediatR;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
	public class ManageUserClaimsQuery : IRequest<Bases.Response<ManageUserClaimsResponse>>
	{
		public int userId { get; set; }
		public ManageUserClaimsQuery(int id)
		{
			userId = id;
		}
	}
}
