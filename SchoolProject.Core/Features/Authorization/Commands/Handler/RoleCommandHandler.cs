﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Handler
{
	public class RoleCommandHandler : ResponseHandler,
									  IRequestHandler<AddRoleCommand, Response<string>>,
									  IRequestHandler<EditRoleCommand, Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly IAuthorizationServices _authorizationService;
		#endregion

		#region Constructors
		public RoleCommandHandler(IMapper mapper,
								  IAuthorizationServices authorizationService,
								  IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_authorizationService = authorizationService;
		}
		#endregion

		#region Haundels Functions
		public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.AddRoleAsync(request.RoleName);
			if (result == "Success") return Success("");
			return BadRequest<string>(_stringLocalizer[SharedResourcesKey.AddFailed]);
		}

		public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.EditRoleAsync(request.roleName, request.id);
			if (result == "notFound") return NotFound<string>();
			else if (result == "Success") return Success("");
			else if (result == "isExist") return BadRequest<string>("Name is already Exist");
			else
				return BadRequest<string>(result);
		}
		#endregion
	}
}