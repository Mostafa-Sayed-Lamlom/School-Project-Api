using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentListMapping()
		{
			CreateMap<Student, GetStudentListResponse>()
				.ForMember(des => des.DeptName,
					opt => opt.MapFrom(src => src.Localize(src.Department.NameAr, src.Department.Name)))
				.ForMember(des => des.Name,
					opt => opt.MapFrom(src => src.Localize(src.NameAr, src.Name)))
				.ForMember(dest => dest.Address,
					opt => opt.MapFrom(src => src.Localize(src.AddressAr, src.Address)));
		}
	}
}
