using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstractions;
using SchoolProject.Service.Implementations;

namespace SchoolProject.Service
{
	public static class ModuleServiceDpendencies
	{
		public static IServiceCollection AddServiceDpendencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentService, StudentService>();
			services.AddTransient<IDepartmentService, DepartmentService>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();
			services.AddTransient<IAuthorizationServices, AuthorizationServices>();
			services.AddTransient<IEmailServices, EmailServices>();
			services.AddTransient<IUserService, UserService>();
			return services;
		}
	}
}
