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
											  IRequestHandler<ValidTokenQuery, Response<string>>
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
		#endregion
	}
}
