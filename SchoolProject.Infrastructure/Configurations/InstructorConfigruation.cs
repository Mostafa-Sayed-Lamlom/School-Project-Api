using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
	public class InstructorConfigruation : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder
			.HasOne(x => x.Supervisor)
			.WithMany(x => x.Instructors)
			.HasForeignKey(x => x.SupervisorId)
			.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
