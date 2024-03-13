using SchoolProject.Data.Entities.Functions;

namespace SchoolProject.Infrastructure.Abstractions.Functions
{
	public interface IInstructorFunctionsRepository
	{
		public decimal GetSalarySummationOfInstructor(string query);
		public Task<List<GetInstructorDataFunctionResult>> GetInstructorData(string query);
	}
}
