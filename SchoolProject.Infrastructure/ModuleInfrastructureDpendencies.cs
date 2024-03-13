using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.views;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Abstractions.Functions;
using SchoolProject.Infrastructure.Abstractions.procedures;
using SchoolProject.Infrastructure.Abstractions.views;
using SchoolProject.Infrastructure.InfrastructureBase;
using SchoolProject.Infrastructure.Repositories;
using SchoolProject.Infrastructure.Repositories.Functions;
using SchoolProject.Infrastructure.Repositories.proceduers;
using SchoolProject.Infrastructure.Repositories.views;

namespace SchoolProject.Infrastructure
{
	public static class ModuleInfrastructureDpendencies
	{
		public static IServiceCollection AddInfrastructureDpendencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentRepository, StudentRepository>();
			services.AddTransient<IDepartmentRepository, DepartmentRepository>();
			services.AddTransient<IInstructorRepository, InstructorRepository>();
			services.AddTransient<ISubjectRepository, SubjectRepository>();
			services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
			services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

			//views
			services.AddTransient<IViewRepository<viewNumStudsInDept>, viewNumStudsInDeptRepository>();
			//procedures
			services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();
			//procedures
			services.AddTransient<IInstructorFunctionsRepository, InstructorFunctionsRepository>();
			return services;
		}
	}
}
