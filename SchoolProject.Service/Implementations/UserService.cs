using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.Identity;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class UserService : IUserService
	{
		#region Fields
		private readonly UserManager<User> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IEmailServices _emailsService;
		private readonly AppDbContext _applicationDBContext;
		private readonly IUrlHelper _urlHelper;
		#endregion
		#region Constructors
		public UserService(UserManager<User> userManager,
									  IHttpContextAccessor httpContextAccessor,
									  IEmailServices emailsService,
									  AppDbContext applicationDBContext,
									  IUrlHelper urlHelper)
		{
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
			_emailsService = emailsService;
			_applicationDBContext = applicationDBContext;
			_urlHelper = urlHelper;
		}
		#endregion
		#region Handle Functions
		public async Task<string> AddUserAsync(User user, string password)
		{
			var trans = await _applicationDBContext.Database.BeginTransactionAsync();
			try
			{
				//if Email is Exist
				var existUser = await _userManager.FindByEmailAsync(user.Email);
				//email is Exist
				if (existUser != null) return "EmailIsExist";

				//if username is Exist
				var userByUserName = await _userManager.FindByNameAsync(user.UserName);
				//username is Exist
				if (userByUserName != null) return "UserNameIsExist";
				//Create
				var createResult = await _userManager.CreateAsync(user, password);
				//Failed
				if (!createResult.Succeeded)
					return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

				await _userManager.AddToRoleAsync(user, "User");

				//Send Confirm Email
				var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
				var resquestAccessor = _httpContextAccessor.HttpContext.Request;
				var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
				var message = $"To Confirm Email Click Link: {returnUrl}";
				//$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
				//message or body
				await _emailsService.sendEmail(user.Email, message, "ConFirm Email");

				await trans.CommitAsync();
				return "Success";
			}
			catch (Exception ex)
			{
				await trans.RollbackAsync();
				return "Failed";
			}

		}
		#endregion
	}
}
