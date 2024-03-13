using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Instructor.Queries.Modles;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class InstructorController : AppControllerBase
	{
		[HttpGet(Router.InstructorRouting.GetSalarySummationOfInstructor)]
		public async Task<IActionResult> GetSalarySummation()
		{
			return NewResult(await _mediator.Send(new GetSummationSalaryOfInstructorQuery()));
		}

		[HttpGet(Router.InstructorRouting.GetInstructorDataFunction)]
		public async Task<IActionResult> GetInstructorDataFunction()
		{
			return NewResult(await _mediator.Send(new GetInstructorDataFunctionQuery()));
		}
	}
}
