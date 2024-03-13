using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructor.Queries.Modles
{
	public class GetSummationSalaryOfInstructorQuery : IRequest<Response<decimal>>
	{
	}
}
