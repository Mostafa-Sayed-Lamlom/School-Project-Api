using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class Student : GeneralLocalizableEntity
	{
		public Student()
		{
			StudentSubjects = new HashSet<StudentSubject>();
		}
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		[StringLength(200)]
		public string? Name { get; set; }
		[StringLength(200)]
		public string? NameAr { get; set; }
		[StringLength(500)]
		public string? Address { get; set; }
		[StringLength(500)]
		public string? AddressAr { get; set; }
		[StringLength(500)]
		public string? Phone { get; set; }
		public int? DId { get; set; }
		[ForeignKey("DId")]
		[InverseProperty("Students")]
		public virtual Department? Department { get; set; }
		[InverseProperty("Student")]
		public ICollection<StudentSubject> StudentSubjects { get; set; }
	}
}
