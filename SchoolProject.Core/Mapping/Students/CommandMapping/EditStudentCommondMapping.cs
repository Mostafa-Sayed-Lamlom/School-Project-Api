using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void EditStudentCommondMapping()
		{
			CreateMap<EditStudentCommand, Student>()
			   .ForMember(dest => dest.DId, opt => opt.MapFrom(src => src.DepartmementId));
		}
	}
}
