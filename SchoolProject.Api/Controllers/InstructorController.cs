using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Instructor.Commands.Models;
using SchoolProject.Core.Features.Instructor.Queries.Modles;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	[Authorize(Roles = "Admin")]
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

		[HttpPost(Router.InstructorRouting.AddInstructor)]
		public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}
	}
}
