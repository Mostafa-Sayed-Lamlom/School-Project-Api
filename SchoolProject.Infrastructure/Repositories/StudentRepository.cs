using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
	public class StudentRepository : GenericRepositoryAsync<Student> ,IStudentRepository
	{
		#region Fields
		private readonly DbSet<Student> _students;
		#endregion
		#region Constructors
		public StudentRepository(AppDbContext DbContext):base(DbContext) 
		{
			_students = DbContext.students;
		}
		#endregion
		#region Handles Functions
		public async Task<List<Student>> GetAllStudentsAsync()
		{
			return await _students.Include(stu => stu.Department).ToListAsync();
		}
		#endregion
	}
}
