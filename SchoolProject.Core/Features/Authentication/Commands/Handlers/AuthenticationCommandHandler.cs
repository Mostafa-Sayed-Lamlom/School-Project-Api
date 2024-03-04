using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
	public class AuthenticationCommandHandler : ResponseHandler,
										 IRequestHandler<SginInCommand, Response<JwtAuthResult>>,
										 IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
	{
		#region Fields
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly SignInManager<SchoolProject.Data.Identity.User> _signInManager;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		private readonly IAuthenticationService _authenticationService;
		#endregion

		#region Constructors
		public AuthenticationCommandHandler(IMapper mapper,
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
		public async Task<Response<JwtAuthResult>> Handle(SginInCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (!user.EmailConfirmed)
				return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKey.EmailNotConfirmed]);

			var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (!signInResult.Succeeded)
				return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKey.EmailOrPassWrong]);
			var TokenGenerated = await _authenticationService.GenerateJWTTokenAsync(user);
			return Success(TokenGenerated);
		}

		public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
		{
			var jwtToken = _authenticationService.ReadJWTToken(request.accessToken);
			var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.accessToken, request.refreshToken);
			switch (userIdAndExpireDate)
			{
				case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResult>("Algorithm Is Wrong");
				case ("TokenIsNotExpired", null): return Unauthorized<JwtAuthResult>("Token Is Not Expired");
				case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResult>("RefreshTokenIsNotFound");
				case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResult>("RefreshTokenIsExpired");
			}
			var (userId, expiryDate) = userIdAndExpireDate;
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound<JwtAuthResult>();
			}
			var result = await _authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.refreshToken);
			return Success(result);
		}
		#endregion
	}
}
