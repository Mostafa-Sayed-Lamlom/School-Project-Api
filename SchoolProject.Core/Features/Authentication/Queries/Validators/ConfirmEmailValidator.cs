using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Queries.Modles;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Queries.Validators
{
	public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _localizer;
		#endregion

		#region Constructors
		public ConfirmEmailValidator(IStringLocalizer<SharResources> localizer)
		{
			_localizer = localizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}

		#endregion
		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.UserId)
			.NotEmpty().WithMessage(_localizer[SharedResourcesKey.NotEmpty])
			.NotNull().WithMessage(_localizer[SharedResourcesKey.Required]);

			RuleFor(x => x.Code)
				.NotEmpty().WithMessage(_localizer[SharedResourcesKey.NotEmpty])
				.NotNull().WithMessage(_localizer[SharedResourcesKey.Required]);
		}

		public void ApplyCustomValidationsRules()
		{
		}

		#endregion
	}
}
