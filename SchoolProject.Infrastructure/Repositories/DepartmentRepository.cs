using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories
{
	public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
	{
		#region Fields
		private readonly DbSet<Department> _departments;
		#endregion

		#region Constructors
		public DepartmentRepository(AppDbContext DbContext) : base(DbContext)
		{
			_departments = DbContext.departments;
		}
		#endregion

		#region Haundle Functions
		#endregion
	}
}
