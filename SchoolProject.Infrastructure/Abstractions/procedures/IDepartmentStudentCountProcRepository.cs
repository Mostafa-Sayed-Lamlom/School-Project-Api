using SchoolProject.Data.Entities.procedures;

namespace SchoolProject.Infrastructure.Abstractions.procedures
{
	public interface IDepartmentStudentCountProcRepository
	{
		public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters);
	}
}
