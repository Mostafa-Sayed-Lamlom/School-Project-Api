using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class Ins_Sub
	{
		[Key]
		public int InsId { get; set; }
		[Key]
		public int SubId { get; set; }


		[ForeignKey("InsId")]
		[InverseProperty("Ins_Sub")]
		public Instructor? Instructor { get; set; }


		[ForeignKey("SubId")]
		[InverseProperty("Ins_Subs")]
		public Subject? Subject { get; set; }
	}
}
