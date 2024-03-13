using SchoolProject.Data.Entities.Functions;
using SchoolProject.Infrastructure.Abstractions.Functions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations
{
	public class InstructorService : IInstructorService
	{
		#region Fileds
		private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
		#endregion
		#region Constructors
		public InstructorService(IInstructorFunctionsRepository instructorFunctionsRepository)
		{
			_instructorFunctionsRepository = instructorFunctionsRepository;
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
		#endregion
	}
}
