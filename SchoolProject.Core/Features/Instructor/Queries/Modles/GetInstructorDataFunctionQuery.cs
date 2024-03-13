using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Queries.Results;

namespace SchoolProject.Core.Features.Instructor.Queries.Modles
{
	public class GetInstructorDataFunctionQuery : IRequest<Response<List<GetInstructorDataFunctionResponseQuery>>>
	{
	}
}
