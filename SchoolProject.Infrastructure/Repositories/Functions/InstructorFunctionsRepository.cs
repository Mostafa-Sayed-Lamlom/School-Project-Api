using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Functions;
using SchoolProject.Infrastructure.Abstractions.Functions;
using SchoolProject.Infrastructure.Context;
using StoredProcedureEFCore;
using System.Data;

namespace SchoolProject.Infrastructure.Repositories.Functions
{
	public class InstructorFunctionsRepository : IInstructorFunctionsRepository
	{
		#region Fileds
		private readonly AppDbContext _dbContext;
		#endregion
		#region Constructors
		public InstructorFunctionsRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		#endregion
		#region Handle Functions
		public decimal GetSalarySummationOfInstructor(string query)
		{
			using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
			{
				if (cmd.Connection.State != ConnectionState.Open)
				{
					cmd.Connection.Open();
				}



				decimal response = 0;
				cmd.CommandText = query;
				var value = cmd.ExecuteScalar();
				var result = value.ToString();
				if (decimal.TryParse(result, out decimal d))
				{
					response = d;
				}
				cmd.Connection.Close();
				return response;
			}
		}
		public async Task<List<GetInstructorDataFunctionResult>> GetInstructorData(string query)
		{
			using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
			{
				if (cmd.Connection.State != ConnectionState.Open)
				{
					cmd.Connection.Open();
				}
				cmd.CommandText = query;

				//read From List
				var reader = await cmd.ExecuteReaderAsync();
				var value = await reader.ToListAsync<GetInstructorDataFunctionResult>();

				cmd.Connection.Close();
				return value;
			}
		}
		#endregion
	}
}
