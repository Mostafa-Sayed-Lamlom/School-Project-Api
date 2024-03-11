using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.procedures;
using SchoolProject.Data.Entities.views;

namespace SchoolProject.Service.Abstractions
{
	public interface IDepartmentService
	{
		public Task<Department> GetDepartmentById(int id);
		public Task<bool> IsDeptIdExist(int id);
		public Task<List<viewNumStudsInDept>> GetViewNumStudsInDeptAsync();
		public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters);
	}
}
