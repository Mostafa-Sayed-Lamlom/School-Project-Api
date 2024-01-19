using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class StudentService : IStudentService
	{
		#region Fields
		private readonly IStudentRepository _studentRepository;
		#endregion
		#region Constructors
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		#endregion
		#region Haundle Functions
		public Task<List<Student>> GetStudentsAsync()
		{
			//your logic
			return _studentRepository.GetAllStudentsAsync();
		}
		public async Task<Student> GetStudentByIdAsync(int id)
		{
			//var student = _studentRepository.GetByIdAsync(id);
			//best performance than List 
			var student = _studentRepository.GetTableNoTracking()
											.Include(s => s.Department)
											.FirstOrDefault(s => s.Id.Equals(id));
			return student;
		}

		public async Task<string> AddStudent(Student student)
		{
			//var stud = _studentRepository.GetTableNoTracking()
			//		  .FirstOrDefault(s => s.Name.Equals(student.Name));
			//if (stud != null) return "Exist";
			await _studentRepository.AddAsync(student);
			return "Success";
		}

		public async Task<bool> IsNameExist(string name)
		{
			var stud = _studentRepository.GetTableNoTracking()
					  .FirstOrDefault(s => s.Name.Equals(name));
			if (stud != null) return true;
			return false;
		}

		public async Task<bool> IsNameExistExcludeSelf(string name, int id)
		{
			var stud = _studentRepository.GetTableNoTracking()
					  .FirstOrDefault(s => s.Name.Equals(name) && !s.Id.Equals(id));
			if (stud != null) return true;
			return false;
		}

		public async Task<string> EditAsync(Student student)
		{
			await _studentRepository.UpdateAsync(student);
			return "Success";
		}

		public async Task<string> DeleteStudentAsync(Student student)
		{
			var trans = _studentRepository.BeginTransaction();
			try
			{
				await _studentRepository.DeleteAsync(student);
				await trans.CommitAsync();
				return "Success";
			}
			catch (Exception ex)
			{
				await trans.RollbackAsync();
				return "Falied";
			}
		}

		public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string s)
		{
			var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
			if (s != null)
			{
				querable = querable.Where(x => x.Name.Contains(s) || x.Address.Contains(s));
			}
			switch (orderingEnum)
			{
				case StudentOrderingEnum.Id:
					querable = querable.OrderBy(x => x.Id);
					break;
				case StudentOrderingEnum.Name:
					querable = querable.OrderBy(x => x.Name);
					break;
				case StudentOrderingEnum.Address:
					querable = querable.OrderBy(x => x.Address);
					break;
				case StudentOrderingEnum.DeptName:
					querable = querable.OrderBy(x => x.Department.Name);
					break;
			}

			return querable;
		}

		public async Task<bool> IsNameArExist(string name)
		{
			var stud = _studentRepository.GetTableNoTracking()
		  .FirstOrDefault(s => s.NameAr.Equals(name));
			if (stud != null) return true;
			return false;
		}

		public async Task<bool> IsNameArExistExcludeSelf(string name, int id)
		{
			var stud = _studentRepository.GetTableNoTracking()
		  .FirstOrDefault(s => s.NameAr.Equals(name) && !s.Id.Equals(id));
			if (stud != null) return true;
			return false;
		}

		public IQueryable<Student> GetStudentByDepartmentIDQueryable(int DID)
		{
			return _studentRepository.GetTableNoTracking().Where(s => s.DId.Equals(DID)).AsQueryable();
		}
		#endregion
	}
}
