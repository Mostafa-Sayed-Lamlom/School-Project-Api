using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
	public class RoleQueryHandler : ResponseHandler,
								   IRequestHandler<GetRolesListQuery, Response<List<GetRoleResponse>>>,
								   IRequestHandler<GetRoleByIdQuery, Response<GetRoleResponse>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly RoleManager<IdentityRole<int>> _roleManager;
		#endregion
		#region Constructors
		public RoleQueryHandler(IMapper mapper,
								RoleManager<IdentityRole<int>> roleManager,
								IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_roleManager = roleManager;
		}
		#endregion
		#region Haundels Functions
		public async Task<Response<List<GetRoleResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
		{
			var rolesList = await _roleManager.Roles.ToListAsync();
			var mapResult = _mapper.Map<List<GetRoleResponse>>(rolesList);
			return Success(mapResult);
		}

		public async Task<Response<GetRoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var role = await _roleManager.FindByIdAsync(request.Id.ToString());
			if (role == null) return NotFound<GetRoleResponse>();
			var mapResult = _mapper.Map<GetRoleResponse>(role);
			return Success(mapResult);
		}


		#endregion
	}
}
