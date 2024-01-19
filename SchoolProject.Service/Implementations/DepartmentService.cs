using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		#region Fields
		private readonly IDepartmentRepository _departmentRepository;
		#endregion
		#region Constructors
		public DepartmentService(IDepartmentRepository repository)
		{
			_departmentRepository = repository;
		}
		#endregion
		#region Haundel Functions
		public async Task<Department> GetDepartmentById(int id)
		{
			var department = await _departmentRepository.GetTableNoTracking()
											  .Where(d => d.Id == id)
											  .Include(d => d.Instructors)
											  .Include(d => d.DepartmentSubject).ThenInclude(s => s.Subject)
											  .Include(d => d.InsManger)
											  .FirstOrDefaultAsync();
			return department;
		}
		#endregion
	}
}
