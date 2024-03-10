using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities.views
{
	[Keyless]
	public class viewNumStudsInDept : GeneralLocalizableEntity
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? NameAr { get; set; }
		public int NumberOfStudents { get; set; }
	}
}
