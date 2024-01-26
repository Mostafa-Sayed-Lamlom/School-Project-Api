using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queries.Models;
using SchoolProject.Core.Features.User.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.User.Queries.Handlers
{
	public class UserQueryHandler : ResponseHandler,
								   IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserLPaginationResponse>>,
								   IRequestHandler<GetUserByIDQuery, Response<GetUserByIDResponse>>
	{
		#region Fileds
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		#endregion
		#region Controllers
		public UserQueryHandler(IMapper mapper,
								UserManager<SchoolProject.Data.Identity.User> userManager,
								IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_userManager = userManager;
			_stringLocalizer = stringLocalizer;
		}
		#endregion
		#region Handle Functions
		public Task<PaginatedResult<GetUserLPaginationResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
		{
			var users = _userManager.Users.AsQueryable();
			var paginatedList = _mapper.ProjectTo<GetUserLPaginationResponse>(users)
									   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
			return paginatedList;
		}

		public async Task<Response<GetUserByIDResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
			if (user == null)
				return NotFound<GetUserByIDResponse>();
			var userMap = _mapper.Map<GetUserByIDResponse>(user);
			return Success(userMap);
		}
		#endregion
	}
}
