using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentByIdMapping()
		{
			CreateMap<Student, GetSingleStudentResponse>()
				.ForMember(des => des.DeptName,
					opt => opt.MapFrom(src => src.Localize(src.Department.NameAr, src.Department.Name)))
				.ForMember(dest => dest.Name,
					opt => opt.MapFrom(src => src.Localize(src.NameAr, src.Name)))
				.ForMember(dest => dest.Address,
					opt => opt.MapFrom(src => src.Localize(src.AddressAr, src.Address)));
		}
	}
}
