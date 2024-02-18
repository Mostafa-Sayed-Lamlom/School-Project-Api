using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
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

		[HttpPut(Router.AuthoriztionRouting.EditRole)]
		public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpDelete(Router.AuthoriztionRouting.DeleteRole)]
		public async Task<IActionResult> DeleteRole([FromRoute] int id)
		{
			var response = await _mediator.Send(new DeleteRoleCommand(id));
			return NewResult(response);
		}

		[HttpGet(Router.AuthoriztionRouting.GetRolesList)]
		public async Task<IActionResult> GetRolesList()
		{
			var response = await _mediator.Send(new GetRolesListQuery());
			return NewResult(response);
		}

		[HttpGet(Router.AuthoriztionRouting.GetRoleById)]
		public async Task<IActionResult> GetRoleById([FromRoute] int id)
		{
			var response = await _mediator.Send(new GetRoleByIdQuery(id));
			return NewResult(response);
		}

		[HttpGet(Router.AuthoriztionRouting.ManageUserRoles)]
		public async Task<IActionResult> ManageUserRoles([FromRoute] int id)
		{
			var response = await _mediator.Send(new ManageUserRolesQuery() { userId = id });
			return NewResult(response);
		}
	}
}
