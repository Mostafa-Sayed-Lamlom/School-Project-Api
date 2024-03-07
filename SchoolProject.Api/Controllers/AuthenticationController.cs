using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Modles;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
	[ApiController]
	public class AuthenticationController : AppControllerBase
	{
		[HttpPost(Router.AuthenticationRouting.SignIn)]
		public async Task<IActionResult> SignInAuth([FromForm] SginInCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpGet(Router.AuthenticationRouting.IsValidToken)]
		public async Task<IActionResult> IsValidToken([FromQuery] ValidTokenQuery command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpPost(Router.AuthenticationRouting.RefreshToken)]
		public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpGet(Router.AuthenticationRouting.ConfirmEmail)]
		public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
		{
			var response = await _mediator.Send(query);
			return NewResult(response);
		}

		[HttpPost(Router.AuthenticationRouting.SendResetPasswordCode)]
		public async Task<IActionResult> SendResetPasswordCode([FromQuery] SendEmailResetPasswordCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpGet(Router.AuthenticationRouting.ConfirmResetPasswordCode)]
		public async Task<IActionResult> ConfirmResetPasswordCode([FromQuery] ConfirmResetPassCodeQuery query)
		{
			var response = await _mediator.Send(query);
			return NewResult(response);
		}

		[HttpPost(Router.AuthenticationRouting.ResetPassword)]
		public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}
