using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Results;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
	public class GetNumStudsOfDeptByIdQuery : IRequest<Response<GetNumStudsOfDeptByIdResponse>>
	{
		public int DID { get; set; }
	}
}
