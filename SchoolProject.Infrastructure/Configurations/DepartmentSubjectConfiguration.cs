using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
	public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
	{
		public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
		{
			builder
			.HasKey(x => new
			{
				x.SubjId,
				x.DepId
			});
		}
	}
}
