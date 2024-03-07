using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validators
{
	public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _localizer;
		#endregion

		#region Constructors
		public ResetPasswordValidator(IStringLocalizer<SharResources> localizer)
		{
			_localizer = localizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}

		#endregion
		#region Handle Functions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Email)
			.NotEmpty().WithMessage(_localizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_localizer[SharedResourcesKey.Required]);
			RuleFor(x => x.Password)
				 .NotEmpty().WithMessage(_localizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_localizer[SharedResourcesKey.Required]);
			RuleFor(x => x.ConfirmPassword)
				 .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKey.passNotEqualConfPass]);

		}

		public void ApplyCustomValidationsRules()
		{

		}

		#endregion
	}
}
