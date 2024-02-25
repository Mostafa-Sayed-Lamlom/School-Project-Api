using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Email.Commands.Handlers
{
	public class EmailCommandHandler : ResponseHandler,
									  IRequestHandler<SendEmailCommand, Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IEmailServices _emailServices;
		#endregion

		#region Constructors
		public EmailCommandHandler(IEmailServices emailServices,
								  IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_emailServices = emailServices;
		}
		#endregion

		#region Haundels Functions
		public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
		{
			var response = await _emailServices.sendEmail(request.email, request.message, null);
			if (response == "Success")
				return Success<string>("");
			return BadRequest<string>(_stringLocalizer[SharedResourcesKey.SendEmailFailed]);
		}
		#endregion
	}
}
