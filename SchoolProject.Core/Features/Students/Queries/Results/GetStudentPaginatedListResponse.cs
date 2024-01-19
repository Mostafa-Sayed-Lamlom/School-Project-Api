namespace SchoolProject.Core.Features.Students.Queries.Results
{
	public class GetStudentPaginatedListResponse
	{
		public GetStudentPaginatedListResponse(int id, string name, string address, string deptName)
		{
			Id = id;
			Name = name;
			Address = address;
			DeptName = deptName;
		}
		public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? DeptName { get; set; }
	}
}
