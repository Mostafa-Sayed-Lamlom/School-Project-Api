using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class Department : GeneralLocalizableEntity
	{
		public Department()
		{
			Students = new HashSet<Student>();
			DepartmentSubject = new HashSet<DepartmentSubject>();
			Instructors = new HashSet<Instructor>();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[StringLength(500)]
		public string? Name { get; set; }
		[StringLength(500)]
		public string? NameAr { get; set; }
		public int? InsMangerId { get; set; }
		[ForeignKey("InsMangerId")]
		[InverseProperty("DeptMange")]
		public virtual Instructor? InsManger { get; set; }

		[InverseProperty("Department")]
		public virtual ICollection<Student> Students { get; set; }
		[InverseProperty("Department")]
		public virtual ICollection<DepartmentSubject> DepartmentSubject { get; set; }
		[InverseProperty("Department")]
		public virtual ICollection<Instructor> Instructors { get; set; }
	}
}
