using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
	public class Ins_SubConfiguration : IEntityTypeConfiguration<Ins_Sub>
	{
		public void Configure(EntityTypeBuilder<Ins_Sub> builder)
		{
			builder
				.HasKey(x => new { x.InsId, x.SubId });
		}
	}
}
