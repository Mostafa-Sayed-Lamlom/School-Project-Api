using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities.Functions
{
	public class GetInstructorDataFunctionResult : GeneralLocalizableEntity
	{
		public int Id { get; set; }
		public string? ENameAr { get; set; }
		public string? ENameEn { get; set; }
	}
}
