namespace SchoolProject.Service.Abstractions
{
	public interface IEmailServices
	{
		public Task<string> sendEmail(string email, string message, string? reason);
	}
}
