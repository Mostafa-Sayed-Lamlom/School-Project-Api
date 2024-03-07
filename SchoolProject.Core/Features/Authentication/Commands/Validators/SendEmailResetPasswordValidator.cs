using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validators
{
	public class SendEmailResetPasswordValidator : AbstractValidator<SendEmailResetPasswordCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public SendEmailResetPasswordValidator(IStringLocalizer<SharResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.Email)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);
		}

		public void ApplyCustomValidationsRules()
		{
		}
		#endregion
	}
}
