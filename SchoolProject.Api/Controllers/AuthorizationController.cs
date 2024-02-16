using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class AuthorizationController : AppControllerBase
	{
		[HttpPost(Router.AuthoriztionRouting.AddRole)]
		public async Task<IActionResult> AddRole([FromForm] AddRoleCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpPost(Router.AuthoriztionRouting.EditRole)]
		public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}
