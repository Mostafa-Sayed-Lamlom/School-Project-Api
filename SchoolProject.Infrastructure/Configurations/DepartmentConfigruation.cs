using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
	public class DepartmentConfigruation : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder
				.HasOne(x => x.InsManger)
				.WithOne(x => x.DeptMange)
				.HasForeignKey<Department>(x => x.InsMangerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
