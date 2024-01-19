using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstractions
{
	public interface IDepartmentService
	{
		public Task<Department> GetDepartmentById(int id);
	}
}
