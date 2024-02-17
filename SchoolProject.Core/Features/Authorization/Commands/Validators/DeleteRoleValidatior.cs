using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
	public class DeleteRoleValidatior : AbstractValidator<DeleteRoleCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		#endregion

		#region Constructors
		public DeleteRoleValidatior(IStringLocalizer<SharResources> stringLocalizer,
								IAuthorizationServices authorizationService)
		{
			_stringLocalizer = stringLocalizer;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Handles Functions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.id)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);
		}
		public async void ApplyCustomValidationsRules()
		{

		}
		#endregion
	}
}
