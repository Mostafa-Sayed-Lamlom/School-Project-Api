using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Functions;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Abstractions.Functions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class InstructorService : IInstructorService
	{
		#region Fileds
		private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
		private readonly IInstructorRepository _instructorsRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IFileService _fileService;
		#endregion
		#region Constructors
		public InstructorService(IInstructorFunctionsRepository instructorFunctionsRepository,
								 IInstructorRepository instructorsRepository,
								 IHttpContextAccessor httpContextAccessor,
								 IFileService fileService)
		{
			_instructorFunctionsRepository = instructorFunctionsRepository;
			_instructorsRepository = instructorsRepository;
			_httpContextAccessor = httpContextAccessor;
			_fileService = fileService;
		}
		#endregion
		#region Handle Functions
		public async Task<decimal> GetSalarySummationOfInstructor()
		{
			decimal result = 0;
			result = _instructorFunctionsRepository.GetSalarySummationOfInstructor("select dbo.GetSalarySummation()");
			return result;
		}
		public Task<List<GetInstructorDataFunctionResult>> GetInstructorData()
		{
			var result = _instructorFunctionsRepository.GetInstructorData("select * from dbo.GetInstructorData()");
			return result;
		}

		public async Task<bool> IsNameArExist(string nameAr)
		{
			//Check if the name is Exist Or not
			var student = _instructorsRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(nameAr)).FirstOrDefault();
			if (student == null) return false;
			return true;
		}

		public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
		{
			//Check if the name is Exist Or not
			var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(nameAr) & x.InsId != id).FirstOrDefaultAsync();
			if (student == null) return false;
			return true;
		}

		public async Task<bool> IsNameEnExist(string nameEn)
		{
			//Check if the name is Exist Or not
			var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(nameEn)).FirstOrDefaultAsync();
			if (student == null) return false;
			return true;
		}

		public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
		{
			//Check if the name is Exist Or not
			var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(nameEn) & x.InsId != id).FirstOrDefaultAsync();
			if (student == null) return false;
			return true;
		}
		public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile file)
		{
			var context = _httpContextAccessor.HttpContext.Request;
			var baseUrl = context.Scheme + "://" + context.Host;
			var imageUrl = await _fileService.UploadImage("Instructors", file);
			switch (imageUrl)
			{
				case "NoImage": return "NoImage";
				case "FailedToUploadImage": return "FailedToUploadImage";
			}
			instructor.Image = baseUrl + imageUrl;
			try
			{
				await _instructorsRepository.AddAsync(instructor);
				return "Success";
			}
			catch (Exception)
			{
				return "FailedInAdd";
			}
		}

		#endregion
	}
}
