using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Abstractions.views
{
	public interface IViewRepository<T> : IGenericRepositoryAsync<T> where T : class
	{
	}
}
