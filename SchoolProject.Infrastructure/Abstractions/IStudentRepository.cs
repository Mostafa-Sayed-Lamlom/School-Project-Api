using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstractions
{
	public interface IStudentRepository : IGenericRepositoryAsync<Student>
	{
		Task<List<Student>> GetAllStudentsAsync();
	}
}
