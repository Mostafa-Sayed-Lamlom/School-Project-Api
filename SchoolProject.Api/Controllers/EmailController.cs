using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class EmailController : AppControllerBase
	{
		[HttpPost(Router.EmailRouting.SendEmail)]
		public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}
