using MediatR;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
	public class AddStudentCommand : IRequest<Bases.Response<string>>
	{
		public string Name { get; set; }
		public string NameAr { get; set; }
		public string Address { get; set; }
		public string AddressAr { get; set; }
		public string Phone { get; set; }
		public int DepartmementId { get; set; }
	}
}
