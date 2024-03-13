using SchoolProject.Core.Features.Instructor.Queries.Results;
using SchoolProject.Data.Entities.Functions;

namespace SchoolProject.Core.Mapping.Instructors
{
	public partial class InstructorProfile
	{
		public void GetInstructorsDataFuncMapping()
		{
			CreateMap<GetInstructorDataFunctionResult, GetInstructorDataFunctionResponseQuery>()
				.ForMember(des => des.Name,
					opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));

		}
	}
}
