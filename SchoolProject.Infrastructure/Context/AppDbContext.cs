using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Entities.views;
using SchoolProject.Data.Identity;
using System.Reflection;

namespace SchoolProject.Infrastructure.Context
{
	public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
	{
		private readonly IEncryptionProvider _encryptionProvider;
		public AppDbContext()
		{

		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			_encryptionProvider = new GenerateEncryptionProvider("8a4dcaaec64d412380fe4b02193cd26f");
		}
		public DbSet<Department> departments { get; set; }
		public DbSet<Student> students { get; set; }
		public DbSet<Subject> subjects { get; set; }
		public DbSet<DepartmentSubject> departmentSubjects { get; set; }
		public DbSet<StudentSubject> studentSubjects { get; set; }
		public DbSet<Instructor> instructors { get; set; }
		public DbSet<Ins_Sub> instructorSubjects { get; set; }
		public DbSet<UserRefreshToken> UserRefreshToken { get; set; }

		//views
		public DbSet<viewNumStudsInDept> viewNumStudsInDept { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
			modelBuilder.UseEncryption(_encryptionProvider);
		}
	}
}
