using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class Subject : GeneralLocalizableEntity
	{
		public Subject()
		{
			StudentSubject = new HashSet<StudentSubject>();
			DepartmentSubject = new HashSet<DepartmentSubject>();
			Ins_Subs = new HashSet<Ins_Sub>();
		}
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[StringLength(500)]
		public string? Name { get; set; }
		public string? NameAr { get; set; }
		public int Period { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<StudentSubject> StudentSubject { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<DepartmentSubject> DepartmentSubject { get; set; }

		[InverseProperty("Subject")]
		public virtual ICollection<Ins_Sub> Ins_Subs { get; set; }
	}
}
