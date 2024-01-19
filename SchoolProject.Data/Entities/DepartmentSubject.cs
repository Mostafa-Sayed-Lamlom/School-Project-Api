using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class DepartmentSubject : GeneralLocalizableEntity
	{
		[Key]
		public int DepId { get; set; }
		[Key]
		public int SubjId { get; set; }
		[ForeignKey("DepId")]
		[InverseProperty("DepartmentSubject")]
		public virtual Department? Department { get; set; }
		[ForeignKey("SubjId")]
		[InverseProperty("DepartmentSubject")]
		public virtual Subject? Subject { get; set; }
	}
}
