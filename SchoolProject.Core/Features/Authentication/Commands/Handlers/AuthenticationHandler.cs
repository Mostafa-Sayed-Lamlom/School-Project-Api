using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
	public class AuthenticationHandler : ResponseHandler,
										 IRequestHandler<SginInCommand, Response<string>>
	{
		#region Fields
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly SignInManager<SchoolProject.Data.Identity.User> _signInManager;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		private readonly IAuthenticationService _authenticationService;
		#endregion

		#region Constructors
		public AuthenticationHandler(IMapper mapper,
									SignInManager<SchoolProject.Data.Identity.User> signInManager,
									IAuthenticationService authenticationService,
									UserManager<SchoolProject.Data.Identity.User> userManager,
									IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_signInManager = signInManager;
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
			_authenticationService = authenticationService;
		}
		#endregion

		#region Handle Functions
		public async Task<Response<string>> Handle(SginInCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (!signInResult.Succeeded)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKey.EmailOrPassWrong]);
			var TokenGenerated = await _authenticationService.GenerateJWTTokenAsync(user);
			return Success(TokenGenerated);
		}
		#endregion
	}
}
