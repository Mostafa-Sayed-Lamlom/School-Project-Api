using SchoolProject.Core.Features.Instructor.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Instructors
{
	public partial class InstructorProfile
	{
		public void AddInstructorMapping()
		{
			CreateMap<AddInstructorCommand, Instructor>()
				.ForMember(dest => dest.Image, opt => opt.Ignore());
		}
	}
}
