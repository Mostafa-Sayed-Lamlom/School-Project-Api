using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
	public class ClaimQueryHandler : ResponseHandler,
									 IRequestHandler<ManageUserClaimsQuery, Bases.Response<ManageUserClaimsResponse>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		#endregion
		#region Constructors
		public ClaimQueryHandler(
								UserManager<SchoolProject.Data.Identity.User> userManager,
								IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
		}
		#endregion
		#region Haundels Functions
		public async Task<Bases.Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.userId.ToString());
			if (user == null) return NotFound<ManageUserClaimsResponse>("user id not found");

			var response = new ManageUserClaimsResponse();
			var usercliamsList = new List<Claim>();
			response.userId = user.Id;
			//Get USer Claims
			var userClaims = await _userManager.GetClaimsAsync(user);

			foreach (var claim in ClaimsStore.claims)
			{
				var userclaim = new Claim();
				userclaim.claimName = claim.Type;
				if (userClaims.Any(x => x.Type == claim.Type))
				{
					userclaim.hasClaim = true;
				}
				else
				{
					userclaim.hasClaim = false;
				}
				usercliamsList.Add(userclaim);
			}
			response.claims = usercliamsList;
			return Success(response);
		}


		#endregion
	}
}
