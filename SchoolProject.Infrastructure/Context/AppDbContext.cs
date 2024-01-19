﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System.Reflection;

namespace SchoolProject.Infrastructure.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext()
		{

		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<Department> departments { get; set; }
		public DbSet<Student> students { get; set; }
		public DbSet<Subject> subjects { get; set; }
		public DbSet<DepartmentSubject> departmentSubjects { get; set; }
		public DbSet<StudentSubject> studentSubjects { get; set; }
		public DbSet<Instructor> instructors { get; set; }
		public DbSet<Ins_Sub> instructorSubjects { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}
