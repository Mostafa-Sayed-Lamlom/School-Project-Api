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
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public EditStudentValidator(IStudentService studentService,
									IStringLocalizer<SharResources> stringLocalizer)
		{
			_studentService = studentService;
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
		}
		public async void ApplyCustomValidationsRules()
		{
			RuleFor(x => x.Name)
			   .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);
			RuleFor(x => x.NameAr)
			   .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(Key, model.Id))
			   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);
		}
		#endregion
	}
}
