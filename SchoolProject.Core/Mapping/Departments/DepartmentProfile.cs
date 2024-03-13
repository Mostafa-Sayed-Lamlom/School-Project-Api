using AutoMapper;

namespace SchoolProject.Core.Mapping.Departments
{
	public partial class InstructorProfile : Profile
	{
		public InstructorProfile()
		{
			GetDepartmentByIdMapping();
			GetNumStudsOfDeptMapping();
			GetNumStudsOfDeptByIdMapping();
		}
	}
}
