using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Queries.Modles;
using SchoolProject.Core.Features.Instructor.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructor.Queries.Handlers
{
	public class InstructorQueryHandler : ResponseHandler,
										  IRequestHandler<GetSummationSalaryOfInstructorQuery, Response<decimal>>,
										  IRequestHandler<GetInstructorDataFunctionQuery, Response<List<GetInstructorDataFunctionResponseQuery>>>
	{

		#region Fileds
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IInstructorService _instructorService;
		#endregion
		#region Constructors
		public InstructorQueryHandler(IStringLocalizer<SharResources> stringLocalizer,
									  IMapper mapper,
									  IInstructorService instructorService) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_instructorService = instructorService;
		}

		#endregion
		#region Handle Functions
		public async Task<Response<decimal>> Handle(GetSummationSalaryOfInstructorQuery request, CancellationToken cancellationToken)
		{
			var result = await _instructorService.GetSalarySummationOfInstructor();
			return Success(result);
		}

		public async Task<Response<List<GetInstructorDataFunctionResponseQuery>>> Handle(GetInstructorDataFunctionQuery request, CancellationToken cancellationToken)
		{
			var result = await _instructorService.GetInstructorData();
			var mapResult = _mapper.Map<List<GetInstructorDataFunctionResponseQuery>>(result);
			return Success(mapResult);
		}
		#endregion
	}
}
