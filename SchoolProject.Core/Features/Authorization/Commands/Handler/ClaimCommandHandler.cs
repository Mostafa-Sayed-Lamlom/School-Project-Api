using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using System.Security.Claims;

namespace SchoolProject.Core.Features.Authorization.Commands.Handler
{
	public class ClaimCommandHandler : ResponseHandler,
									  IRequestHandler<UpdateUserClaimsCommand, Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		#endregion

		#region Constructors
		public ClaimCommandHandler(IMapper mapper,
								  UserManager<SchoolProject.Data.Identity.User> userManager,
		IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_userManager = userManager;
		}
		#endregion

		#region Haundels Functions
		public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.userId.ToString());
			if (user == null) return NotFound<string>("user id not found");

			var userOldClaims = await _userManager.GetClaimsAsync(user);
			var result = await _userManager.RemoveClaimsAsync(user, userOldClaims);
			if (!result.Succeeded) return BadRequest<string>("Faild to remove old user claims");

			var userNewClaims = request.claims.Where(c => c.hasClaim == true).Select(c => new Claim(c.claimName, c.hasClaim.ToString()));
			var resultOfAddingRoles = await _userManager.AddClaimsAsync(user, userNewClaims);
			if (resultOfAddingRoles.Succeeded)
				return Success("");
			return BadRequest<string>("Faild to update user claims");
			throw new NotImplementedException();
		}
		#endregion
	}
}
