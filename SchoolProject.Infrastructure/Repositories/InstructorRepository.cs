using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories
{
	public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
	{
		#region Fields
		private readonly DbSet<Instructor> _instructors;
		#endregion

		#region Constructors
		public InstructorRepository(AppDbContext DbContext) : base(DbContext)
		{
			_instructors = DbContext.instructors;
		}
		#endregion

		#region Haundle Functions
		#endregion
	}
}
