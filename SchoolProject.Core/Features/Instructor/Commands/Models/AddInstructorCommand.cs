using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructor.Commands.Models
{
	public class AddInstructorCommand : IRequest<Response<string>>
	{
		public string? ENameAr { get; set; }
		public string? ENameEn { get; set; }
		public string? Address { get; set; }
		public string? Position { get; set; }
		public int? SupervisorId { get; set; }
		public decimal? Salary { get; set; }
		public int DID { get; set; }
		public IFormFile? Image { get; set; }
	}
}
