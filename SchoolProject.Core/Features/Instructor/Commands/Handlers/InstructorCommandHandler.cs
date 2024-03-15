using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructor.Commands.Handlers
{
	public class InstructorCommandHandler : ResponseHandler,
											IRequestHandler<AddInstructorCommand, Response<string>>
	{

		#region Fileds
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharResources> _localizer;
		private readonly IInstructorService _instructorService;
		#endregion
		#region Constructors
		public InstructorCommandHandler(IStringLocalizer<SharResources> stringLocalizer,
										IMapper mapper,
										IInstructorService instructorService) : base(stringLocalizer)
		{
			_instructorService = instructorService;
			_mapper = mapper;
			_localizer = stringLocalizer;
		}


		#endregion
		#region Handle Functions
		public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
		{
			var instructor = _mapper.Map<SchoolProject.Data.Entities.Instructor>(request);
			var result = await _instructorService.AddInstructorAsync(instructor, request.Image);
			switch (result)
			{
				case "NoImage": return BadRequest<string>(_localizer[SharedResourcesKey.NoImage]);
				case "FailedToUploadImage": return BadRequest<string>(_localizer[SharedResourcesKey.FailedToUploadImage]);
				case "FailedInAdd": return BadRequest<string>(_localizer[SharedResourcesKey.AddFailed]);
			}
			return Success("");
		}
		#endregion
	}
}
