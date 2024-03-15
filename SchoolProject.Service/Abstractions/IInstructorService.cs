using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Functions;

namespace SchoolProject.Service.Abstractions
{
	public interface IInstructorService
	{
		public Task<decimal> GetSalarySummationOfInstructor();
		public Task<List<GetInstructorDataFunctionResult>> GetInstructorData();
		public Task<bool> IsNameArExist(string nameAr);
		public Task<bool> IsNameEnExist(string nameEn);
		public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
		public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
		public Task<string> AddInstructorAsync(Instructor instructor, IFormFile file);
	}
}
