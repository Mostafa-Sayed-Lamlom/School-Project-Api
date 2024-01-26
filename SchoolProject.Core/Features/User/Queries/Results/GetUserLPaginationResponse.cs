namespace SchoolProject.Core.Features.User.Queries.Results
{
	public class GetUserLPaginationResponse
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
