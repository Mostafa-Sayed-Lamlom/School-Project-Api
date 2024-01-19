using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class StudentSubject
	{
		[Key]
		public int StuId { get; set; }
		[Key]
		public int SubId { get; set; }
		public decimal grade { get; set; }
		[ForeignKey("StuId")]
		[InverseProperty("StudentSubjects")]
		public virtual Student? Student { get; set; }
		[ForeignKey("SubId")]
		[InverseProperty("StudentSubject")]
		public virtual Subject? Subject { get; set; }
	}
}
