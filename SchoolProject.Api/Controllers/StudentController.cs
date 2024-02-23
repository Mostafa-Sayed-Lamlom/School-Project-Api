using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	[Authorize]
	public class StudentController : AppControllerBase
	{

		[HttpGet(Router.StudentRouting.List)]
		public async Task<IActionResult> GetStudentList()
		{
			var response = await _mediator.Send(new GetStudentListQuery());
			return NewResult(response);
		}
		[AllowAnonymous]

		[HttpGet(Router.StudentRouting.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery paginatedListQuery)
		{
			var response = await _mediator.Send(paginatedListQuery);
			return Ok(response);
		}


		[HttpGet(Router.StudentRouting.GetById)]
		public async Task<IActionResult> GetStudentById([FromRoute] int id)
		{
			var response = await _mediator.Send(new GetStudentByIdQuery(id));
			return NewResult(response);
		}

		[Authorize(Policy = "CreateStudent")]
		[HttpPost(Router.StudentRouting.Create)]
		public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[Authorize(Policy = "EditStudent")]
		[HttpPut(Router.StudentRouting.Edit)]
		public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[Authorize(Policy = "DeleteStudent")]
		[HttpDelete(Router.StudentRouting.Delete)]
		public async Task<IActionResult> DeleteStudent([FromRoute] int id)
		{
			var response = await _mediator.Send(new DeleteStudentCommand(id));
			return NewResult(response);
		}
	}
}
