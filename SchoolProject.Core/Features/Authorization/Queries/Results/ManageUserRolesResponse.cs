namespace SchoolProject.Core.Features.Authorization.Queries.Results
{
	public class ManageUserRolesResponse
	{
		public int userId { get; set; }
		public List<Role> roles { get; set; }
	}
	public class Role
	{
		public int roleId { get; set; }
		public string roleName { get; set; }
		public bool hasRole { get; set; }
	}
}
