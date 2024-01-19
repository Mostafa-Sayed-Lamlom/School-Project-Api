using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories
{
	public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
	{
		#region Fields
		private readonly DbSet<Subject> _subjects;
		#endregion

		#region Constructors
		public SubjectRepository(AppDbContext DbContext) : base(DbContext)
		{
			_subjects = DbContext.subjects;
		}
		#endregion

		#region Haundle Functions
		#endregion
	}
}
