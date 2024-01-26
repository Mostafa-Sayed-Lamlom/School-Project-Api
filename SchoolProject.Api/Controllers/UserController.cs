using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Features.User.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class UserController : AppControllerBase
	{
		[HttpPost(Router.UserRouting.Create)]
		public async Task<IActionResult> GetDepartmentById([FromBody] AddUserCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpGet(Router.UserRouting.Paginated)]
		public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery paginatedListQuery)
		{
			var response = await _mediator.Send(paginatedListQuery);
			return Ok(response);
		}

		[HttpGet(Router.UserRouting.GetById)]
		public async Task<IActionResult> GetUserById([FromRoute] int id)
		{
			var response = await _mediator.Send(new GetUserByIDQuery() { Id = id });
			return NewResult(response);
		}
	}
}
