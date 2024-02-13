using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.InfrastructureBase;
using SchoolProject.Infrastructure.Repositories;

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

			return services;
		}
	}
}
