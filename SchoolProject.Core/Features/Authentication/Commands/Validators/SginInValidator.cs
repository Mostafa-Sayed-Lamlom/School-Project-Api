using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validators
{
	public class SginInValidator : AbstractValidator<SginInCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public SginInValidator(IStringLocalizer<SharResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Handles Functions
		public void ApplyValidationsRules()
		{
			//RuleFor(x => x.Id)
			//	 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
			//	 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);

			RuleFor(x => x.Email)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);
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
