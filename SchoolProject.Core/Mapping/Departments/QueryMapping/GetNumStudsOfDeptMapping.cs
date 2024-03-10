using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Data.Entities.views;

namespace SchoolProject.Core.Mapping.Departments
{
	public partial class DepartmentProfile
	{
		public void GetNumStudsOfDeptMapping()
		{
			CreateMap<viewNumStudsInDept, GetNumStudsOfDeptResponse>()
				.ForMember(des => des.Name,
					opt => opt.MapFrom(src => src.Localize(src.NameAr, src.Name)));
		}
	}
}
