using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Queries.Modles;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
	public class AuthenticationQueryHandler : ResponseHandler,
											  IRequestHandler<ValidTokenQuery, Response<string>>,
											  IRequestHandler<ConfirmEmailQuery, Response<string>>,
											  IRequestHandler<ConfirmResetPassCodeQuery, Response<string>>
	{
		#region Fields
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IAuthenticationService _authenticationService;
		#endregion

		#region Constructors
		public AuthenticationQueryHandler(IMapper mapper,
									IAuthenticationService authenticationService,
									IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_authenticationService = authenticationService;
		}
		#endregion

		#region Handle Functions
		public async Task<Response<string>> Handle(ValidTokenQuery request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.ValidateToken(request.Token);
			if (result == "NotExpired")
				return Success(result);
			return Unauthorized<string>("Token is Expired");
		}

		public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
		{
			var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);
			if (confirmEmail == "ErrorWhenConfirmEmail")
				return BadRequest<string>(_stringLocalizer[SharedResourcesKey.ErrorWhenConfirmEmail]);
			return Success<string>(_stringLocalizer[SharedResourcesKey.ConfirmEmailDone]);
			throw new NotImplementedException();
		}

		public async Task<Response<string>> Handle(ConfirmResetPassCodeQuery request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.ConfirmResetPassword(request.Code, request.Email);
			switch (result)
			{
				case "UserNotFound": return BadRequest<string>(_stringLocalizer[SharedResourcesKey.UserNotFound]);
				case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKey.InvaildCode]);
				case "Success": return Success<string>("");
				default: return BadRequest<string>(_stringLocalizer[SharedResourcesKey.InvaildCode]);
			}
		}
		#endregion
	}
}
