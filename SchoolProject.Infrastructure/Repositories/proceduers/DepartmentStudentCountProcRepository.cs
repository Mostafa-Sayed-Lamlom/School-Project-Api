using SchoolProject.Data.Entities.procedures;
using SchoolProject.Infrastructure.Abstractions.procedures;
using SchoolProject.Infrastructure.Context;
using StoredProcedureEFCore;

namespace SchoolProject.Infrastructure.Repositories.proceduers
{
	public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
	{
		#region Fields
		private readonly AppDbContext _context;
		#endregion
		#region Constructors
		public DepartmentStudentCountProcRepository(AppDbContext context)
		{
			_context = context;
		}
		#endregion
		#region Handle Functions
		public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters)
		{
			var rows = new List<DepartmentStudentCountProc>();
			await _context.LoadStoredProc(nameof(DepartmentStudentCountProc))
				   .AddParam(nameof(DepartmentStudentCountProcParameters.DID), parameters.DID)
				   .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());
			return rows;
		}
		#endregion
	}
}
