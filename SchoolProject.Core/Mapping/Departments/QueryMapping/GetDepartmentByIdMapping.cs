using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments
{
	public partial class DepartmentProfile
	{
		public void GetDepartmentByIdMapping()
		{
			CreateMap<Department, GetDepartmentByIdResponse>()
				.ForMember(des => des.Name,
					opt => opt.MapFrom(src => src.Localize(src.NameAr, src.Name)))
			.ForMember(des => des.MangerName,
					opt => opt.MapFrom(src => src.Localize(src.InsManger.ENameAr, src.InsManger.ENameEn)))
			//.ForMember(des => des.StudentList, opt => opt.MapFrom(src => src.Students))
			.ForMember(des => des.InstructorList, opt => opt.MapFrom(src => src.Instructors))
			.ForMember(des => des.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubject));

			//CreateMap<Student, StudentResponse>()
			//	.ForMember(des => des.Name,
			//		opt => opt.MapFrom(src => src.Localize(src.NameAr, src.Name)))
			//	.ForMember(des => des.ID, opt => opt.MapFrom(src => src.DId));

			CreateMap<Instructor, InstructorResponse>()
				.ForMember(des => des.Name,
					opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)))
				.ForMember(des => des.ID, opt => opt.MapFrom(src => src.InsId));

			CreateMap<DepartmentSubject, SubjectResponse>()
				.ForMember(des => des.Name,
					opt => opt.MapFrom(src => src.Localize(src.Subject.NameAr, src.Subject.Name)))
				.ForMember(des => des.ID, opt => opt.MapFrom(src => src.SubjId));
		}
	}
}
