using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolProject.Data.Identity;
using SchoolProject.Service.AuthServices.Interfaces;

namespace SchoolProject.Core.Filters
{
	public class AuthFilter : IAsyncActionFilter
	{
		#region Fields
		private readonly ICurrentUserServices _currentUserService;
		private readonly UserManager<User> _userManager;
		#endregion
		#region Constructors
		public AuthFilter(ICurrentUserServices currentUserService)
		{
			_currentUserService = currentUserService;
		}
		#endregion
		#region Handle Functions
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (context.HttpContext.User.Identity.IsAuthenticated == true)
			{
				var roles = await _currentUserService.GetCurrentUserRolesAsync();
				if (roles.All(x => x != "User"))
				{
					context.Result = new ObjectResult("Forbidden")
					{
						StatusCode = StatusCodes.Status403Forbidden
					};
				}
				else
				{
					await next();
				}

			}
		}
		#endregion
	}
}
