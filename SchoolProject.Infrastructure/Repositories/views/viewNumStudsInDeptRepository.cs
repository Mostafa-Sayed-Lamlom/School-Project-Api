using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.views;
using SchoolProject.Infrastructure.Abstractions.views;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories.views
{
	public class viewNumStudsInDeptRepository : GenericRepositoryAsync<viewNumStudsInDept>, IViewRepository<viewNumStudsInDept>
	{
		#region Fields
		private DbSet<viewNumStudsInDept> viewNumStudsInDept;
		#endregion

		#region Constructors
		public viewNumStudsInDeptRepository(AppDbContext dbContext) : base(dbContext)
		{
			viewNumStudsInDept = dbContext.Set<viewNumStudsInDept>();
		}
		#endregion

		#region Handle Functions
		#endregion
	}
}
