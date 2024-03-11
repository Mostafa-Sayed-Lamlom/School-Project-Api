using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.procedures;
using SchoolProject.Data.Entities.views;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Abstractions.procedures;
using SchoolProject.Infrastructure.Abstractions.views;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		#region Fields
		private readonly IDepartmentRepository _departmentRepository;
		private readonly IViewRepository<viewNumStudsInDept> _viewNumStudsInDept;
		private readonly IDepartmentStudentCountProcRepository _departmentStudentCountProcRepository;
		#endregion
		#region Constructors
		public DepartmentService(IDepartmentRepository repository,
								 IViewRepository<viewNumStudsInDept> viewNumStudsInDept,
								 IDepartmentStudentCountProcRepository departmentStudentCountProcRepository)
		{
			_departmentRepository = repository;
			_viewNumStudsInDept = viewNumStudsInDept;
			_departmentStudentCountProcRepository = departmentStudentCountProcRepository;
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

		public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters)
		{
			return await _departmentStudentCountProcRepository.GetDepartmentStudentCountProcs(parameters);
		}

		public async Task<List<viewNumStudsInDept>> GetViewNumStudsInDeptAsync()
		{
			var viewDepartment = await _viewNumStudsInDept.GetTableNoTracking().ToListAsync();
			return viewDepartment;
		}

		public async Task<bool> IsDeptIdExist(int id)
		{
			var dept = await _departmentRepository.GetTableNoTracking().AnyAsync(d => d.Id.Equals(id));
			return dept;
		}
		#endregion
	}
}
