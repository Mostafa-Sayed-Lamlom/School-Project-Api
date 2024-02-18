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
								   IRequestHandler<GetRoleByIdQuery, Response<GetRoleResponse>>,
								   IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResponse>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly RoleManager<IdentityRole<int>> _roleManager;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		#endregion
		#region Constructors
		public RoleQueryHandler(IMapper mapper,
								RoleManager<IdentityRole<int>> roleManager,
								UserManager<SchoolProject.Data.Identity.User> userManager,
								IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_roleManager = roleManager;
			_userManager = userManager;
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

		public async Task<Response<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
		{
			var response = new ManageUserRolesResponse();
			response.roles = new List<Role>();

			var roles = await _roleManager.Roles.ToListAsync();
			var user = await _userManager.FindByIdAsync(request.userId.ToString());
			if (user == null) return NotFound<ManageUserRolesResponse>();

			response.userId = user.Id;
			foreach (var role in roles)
			{
				var role2 = new Role();
				role2.roleId = role.Id;
				role2.roleName = role.Name;
				if (await _userManager.IsInRoleAsync(user, role.Name))
					role2.hasRole = true;
				else
					role2.hasRole = false;

				response.roles.Add(role2);
			}
			return Success(response);
		}


		#endregion
	}
}
