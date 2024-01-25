using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.User.Commands.Models;
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
	}
}
