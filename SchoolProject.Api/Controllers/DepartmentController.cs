using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : AppControllerBase
	{
		[HttpGet(Router.DepartmentRouting.GetById)]
		public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
		{
			var response = await _mediator.Send(query);
			return NewResult(response);
		}

		[HttpGet(Router.DepartmentRouting.GetNumStudsOfDept)]
		public async Task<IActionResult> GetNumStudsOfDept()
		{
			return NewResult(await _mediator.Send(new GetNumStudsOfDeptQuery()));
		}

		[HttpGet(Router.DepartmentRouting.GetNumStudsOfDeptById)]
		public async Task<IActionResult> GetNumStudsOfDeptById([FromRoute] int id)
		{
			return NewResult(await _mediator.Send(new GetNumStudsOfDeptByIdQuery { DID = id }));
		}
	}
}
