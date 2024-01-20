using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
	public class EditStudentValidator : AbstractValidator<EditStudentCommand>
	{
		#region Fields
		IStudentService _studentService;
		IDepartmentService _DepartmentService;
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public EditStudentValidator(IStudentService studentService,
									IDepartmentService departmentService,
									IStringLocalizer<SharResources> stringLocalizer)
		{
			_studentService = studentService;
			_DepartmentService = departmentService;
			_stringLocalizer = stringLocalizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Handles Functions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Name)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				 .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.NameAr)
			 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
			 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
			 .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.AddressAr)
				.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.DepartmementId)
				.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);
		}
		public async void ApplyCustomValidationsRules()
		{
			RuleFor(x => x.Name)
			   .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);
			RuleFor(x => x.NameAr)
			   .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(Key, model.Id))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);
			RuleFor(x => x.DepartmementId)
			   .MustAsync(async (Key, CancellationToken) => await _DepartmentService.IsDeptIdExist(Key))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsNotExist]);
		}
		#endregion
	}
}
