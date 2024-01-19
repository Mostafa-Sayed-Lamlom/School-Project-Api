using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
	public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
	{
		public void Configure(EntityTypeBuilder<StudentSubject> builder)
		{
			builder
				.HasKey(x => new { x.StuId, x.SubId });
		}
	}
}
