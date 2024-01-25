using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.User.Commands.Handlers
{
	public class UserCommandHandler : ResponseHandler,
									 IRequestHandler<AddUserCommand, Response<string>>
	{
		#region Fileds
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		#endregion
		#region Controllers
		public UserCommandHandler(IMapper mapper,
								  UserManager<SchoolProject.Data.Identity.User> userManager,
								  IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_userManager = userManager;
			_stringLocalizer = stringLocalizer;
		}
		#endregion
		#region Handle Functions
		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			var IsUserEmailExist = await _userManager.FindByEmailAsync(request.Email);
			if (IsUserEmailExist != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKey.EmailIsExist]);


			var IsUserNameExist = await _userManager.FindByNameAsync(request.UserName);
			if (IsUserNameExist != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKey.UserNameIsExist]);


			var newUser = _mapper.Map<SchoolProject.Data.Identity.User>(request);
			var CreateResult = _userManager.CreateAsync(newUser, request.Password);

			if (!CreateResult.Result.Succeeded)
				//return BadRequest<string>(_stringLocalizer[SharedResourcesKey.AddUserFaild]);
				return BadRequest<string>(CreateResult.Result.Errors.FirstOrDefault().Description);

			return Created("");
		}
		#endregion
	}
}
