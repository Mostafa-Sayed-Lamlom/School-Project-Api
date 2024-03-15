using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Instructor.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructor.Commands.Validators
{
	public class AddInstructorValidator : AbstractValidator<AddInstructorCommand>
	{
		#region Fields
		private readonly IInstructorService _instructorService;
		private readonly IDepartmentService _DepartmentService;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public AddInstructorValidator(IInstructorService instructorService,
								   IDepartmentService DepartmentService,
								   IStringLocalizer<SharResources> stringLocalizer)
		{
			_instructorService = instructorService;
			_stringLocalizer = stringLocalizer;
			_DepartmentService = DepartmentService;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Handles Functions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.ENameAr)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				 .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.ENameEn)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				 .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.DID)
				.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);
		}
		public async void ApplyCustomValidationsRules()
		{
			RuleFor(x => x.ENameAr)
			   .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameArExist(Key))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);

			RuleFor(x => x.ENameEn)
			   .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameArExist(Key))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);

			RuleFor(x => x.DID)
			   .MustAsync(async (Key, CancellationToken) => await _DepartmentService.IsDeptIdExist(Key))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsNotExist]);
		}
		#endregion
	}
}
