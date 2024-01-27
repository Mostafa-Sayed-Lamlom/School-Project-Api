using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.User.Commands.Validators
{
	public class EditUserValidator : AbstractValidator<EditUserCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public EditUserValidator(IStringLocalizer<SharResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Handles Functions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.FullName)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				 .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

			RuleFor(x => x.Email)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);

			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

		}
		public async void ApplyCustomValidationsRules()
		{
			//RuleFor(x => x.Name)
			//   .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
			//   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);

			//RuleFor(x => x.NameAr)
			//   .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameArExist(Key))
			//   .WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);

			//RuleFor(x => x.DepartmementId)
			//   .MustAsync(async (Key, CancellationToken) => await _DepartmentService.IsDeptIdExist(Key))
			//   .WithMessage(_stringLocalizer[SharedResourcesKey.IsNotExist]);
		}
		#endregion



	}
}
