using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.procedures;
using SchoolProject.Service.Abstractions;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Haundlers
{
	public class DepartmentQueryHaundler : ResponseHandler,
										   IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
										   IRequestHandler<GetNumStudsOfDeptQuery, Response<List<GetNumStudsOfDeptResponse>>>,
										   IRequestHandler<GetNumStudsOfDeptByIdQuery, Response<GetNumStudsOfDeptByIdResponse>>
	{
		#region Fields
		private readonly IDepartmentService _departmentService;
		private readonly IStudentService _studentService;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IMapper _mapper;
		#endregion
		#region Constructors
		public DepartmentQueryHaundler(IDepartmentService departmentService,
									   IMapper mapper,
									   IStudentService studentService,
									   IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_departmentService = departmentService;
			_studentService = studentService;
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
		}
		#endregion
		#region Haundels Functions
		public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
		{
			//servicegetby Id include st sub inst
			var dept = await _departmentService.GetDepartmentById(request.Id);
			//check if exist or not
			if (dept == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
			//mapping
			var result = _mapper.Map<GetDepartmentByIdResponse>(dept);
			//paginations
			Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.Id, e.Localize(e.NameAr, e.Name));
			var studentQuerable = _studentService.GetStudentByDepartmentIDQueryable(request.Id);
			var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
			result.StudentList = PaginatedList;
			return Success(result);
		}

		public async Task<Response<List<GetNumStudsOfDeptResponse>>> Handle(GetNumStudsOfDeptQuery request, CancellationToken cancellationToken)
		{
			var viewDepartmentResult = await _departmentService.GetViewNumStudsInDeptAsync();
			var result = _mapper.Map<List<GetNumStudsOfDeptResponse>>(viewDepartmentResult);
			return Success(result);
		}

		public async Task<Response<GetNumStudsOfDeptByIdResponse>> Handle(GetNumStudsOfDeptByIdQuery request, CancellationToken cancellationToken)
		{
			var dept = await _departmentService.GetDepartmentById(request.DID);
			//check if exist or not
			if (dept == null) return NotFound<GetNumStudsOfDeptByIdResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);

			var parameters = _mapper.Map<DepartmentStudentCountProcParameters>(request);
			var procResult = await _departmentService.GetDepartmentStudentCountProcs(parameters);
			var result = _mapper.Map<GetNumStudsOfDeptByIdResponse>(procResult.FirstOrDefault());
			return Success(result);
		}


		#endregion
	}
}
