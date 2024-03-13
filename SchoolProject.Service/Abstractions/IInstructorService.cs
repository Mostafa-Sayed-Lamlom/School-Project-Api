using SchoolProject.Data.Entities.Functions;

namespace SchoolProject.Service.Abstractions
{
	public interface IInstructorService
	{
		public Task<decimal> GetSalarySummationOfInstructor();
		public Task<List<GetInstructorDataFunctionResult>> GetInstructorData();
	}
}
