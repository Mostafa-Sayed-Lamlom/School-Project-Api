namespace SchoolProject.Core.Features.Authorization.Queries.Results
{
	public class ManageUserClaimsResponse
	{
		public int userId { get; set; }
		public List<Claim> claims { get; set; }
	}
	public class Claim
	{
		public string claimName { get; set; }
		public bool hasClaim { get; set; }
	}
}
