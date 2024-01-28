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
									 IRequestHandler<AddUserCommand, Response<string>>,
									 IRequestHandler<EditUserCommand, Response<string>>,
									 IRequestHandler<DeleteUserCommand, Response<string>>
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
			var CreateResult = await _userManager.CreateAsync(newUser, request.Password);

			if (!CreateResult.Succeeded)
				//return BadRequest<string>(_stringLocalizer[SharedResourcesKey.AddUserFaild]);
				return BadRequest<string>(CreateResult.Errors.FirstOrDefault().Description);

			return Created("");
		}

		public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
		{
			var IsUserExist = await _userManager.FindByIdAsync(request.Id.ToString());
			if (IsUserExist == null)
				return NotFound<string>();


			var IsUserEmailExist = _userManager.Users.AsQueryable()
									.FirstOrDefault(u => u.Email == request.Email && u.Id != request.Id);
			if (IsUserEmailExist != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKey.EmailIsExist]);


			var IsUserNameExist = _userManager.Users.AsQueryable()
									.FirstOrDefault(u => u.UserName == request.UserName && u.Id != request.Id);
			if (IsUserNameExist != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKey.UserNameIsExist]);


			var newUser = _mapper.Map(request, IsUserExist);
			var CreateResult = await _userManager.UpdateAsync(newUser);
			if (!CreateResult.Succeeded)
				return BadRequest<string>(CreateResult.Errors.FirstOrDefault().Description);

			return Success<string>("");
		}

		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var IsUserExist = await _userManager.FindByIdAsync(request.Id.ToString());
			if (IsUserExist == null)
				return NotFound<string>();

			var deleteResult = await _userManager.DeleteAsync(IsUserExist);
			if (!deleteResult.Succeeded)
				return BadRequest<string>(deleteResult.Errors.FirstOrDefault().Description);

			return Deleted<string>();
		}
		#endregion
	}
}
