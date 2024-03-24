using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Students.Commands.Haundlers
{
	public class StudentCommandHandler : ResponseHandler,
				IRequestHandler<AddStudentCommand, Response<string>>,
				IRequestHandler<EditStudentCommand, Response<string>>,
				IRequestHandler<DeleteStudentCommand, Response<string>>
	{
		#region Fileds
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion
		#region Controllers
		public StudentCommandHandler(IStudentService studentService,
									 IMapper mapper,
									 IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
		}
		#endregion
		#region Handle Functions
		public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			//mapp
			var studentMapper = _mapper.Map<Student>(request);
			//add
			var result = await _studentService.AddStudent(studentMapper);
			//check
			//if (result == "Exist") return UnprocessableEntity<string>("Name is Exist");
			if (result == "Success") return Created("");
			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			int x = 2;
			//chek id(found or not)
			var student = await _studentService.GetStudentByIdAsync(request.Id);
			//not found
			if (student == null) return NotFound<string>();
			//mapp
			var studentMapper = _mapper.Map(request, student);
			//edit service
			var result = await _studentService.EditAsync(studentMapper);
			if (result == "Success") return Success("");
			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			//chek id(found or not)
			var student = await _studentService.GetStudentByIdAsync(request.Id);
			//not found
			if (student == null) return NotFound<string>();
			// delete service
			var result = await _studentService.DeleteStudentAsync(student);
			if (result == "Success") return Deleted<string>();
			else return BadRequest<string>();
		}
		#endregion
	}
}
