using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstractions
{
	public interface IStudentService
	{
		Task<List<Student>> GetStudentsAsync();
		Task<Student> GetStudentByIdAsync(int id);
		Task<string> AddStudent(Student student);
		Task<bool> IsNameExist(string name);
		Task<bool> IsNameArExist(string name);
		Task<bool> IsNameExistExcludeSelf(string name, int id);
		Task<bool> IsNameArExistExcludeSelf(string name, int id);
		Task<string> EditAsync(Student student);
		Task<string> DeleteStudentAsync(Student student);
		IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string s);
		IQueryable<Student> GetStudentByDepartmentIDQueryable(int DID);
	}
}
