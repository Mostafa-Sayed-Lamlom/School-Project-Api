using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Data.Entities.procedures;

namespace SchoolProject.Core.Mapping.Departments
{
	public partial class InstructorProfile
	{
		public void GetNumStudsOfDeptByIdMapping()
		{
			CreateMap<GetNumStudsOfDeptByIdQuery, DepartmentStudentCountProcParameters>();

			CreateMap<DepartmentStudentCountProc, GetNumStudsOfDeptByIdResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
				.ForMember(dest => dest.NumberOfStudents, opt => opt.MapFrom(src => src.StudentCount));
		}
	}
}
