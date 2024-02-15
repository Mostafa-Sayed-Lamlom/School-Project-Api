using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
	public class AddRoleValidator : AbstractValidator<AddRoleCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IAuthorizationServices _authorizationService;
		#endregion

		#region Constructors
		public AddRoleValidator(IStringLocalizer<SharResources> stringLocalizer,
								IAuthorizationServices authorizationService)
		{
			_stringLocalizer = stringLocalizer;
			_authorizationService = authorizationService;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Handles Functions
		public void ApplyValidationsRules()
		{
			RuleFor(x => x.RoleName)
				 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
				 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required]);
		}
		public async void ApplyCustomValidationsRules()
		{
			RuleFor(x => x.RoleName)
				.MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExistByName(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKey.IsExist]);
		}
		#endregion
	}
}
