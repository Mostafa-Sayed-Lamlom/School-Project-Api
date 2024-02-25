using MailKit.Net.Smtp;
using MimeKit;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class EmailServices : IEmailServices
	{
		#region Fields
		private readonly emailSettings _emailSettings;
		#endregion
		#region Constructors
		public EmailServices(emailSettings emailSettings)
		{
			_emailSettings = emailSettings;
		}
		#endregion
		#region Haundle Functions
		public async Task<string> sendEmail(string email, string message, string? reason)
		{
			try
			{
				//sending the Message of passwordResetLink
				using (var client = new SmtpClient())
				{
					await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
					client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
					var bodybuilder = new BodyBuilder
					{
						HtmlBody = $"{message}",
						TextBody = "wellcome",
					};
					var Message = new MimeMessage
					{
						Body = bodybuilder.ToMessageBody()
					};
					Message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
					Message.To.Add(new MailboxAddress("testing", email));
					Message.Subject = reason == null ? "No Submitted" : reason;
					await client.SendAsync(Message);
					await client.DisconnectAsync(true);
				}
				//end of sending email
				return "Success";
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion
	}
}
