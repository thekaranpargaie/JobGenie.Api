using Microsoft.Extensions.DependencyInjection;
using Resume.Infrastructure.Repositories.Implementation;
using Resume.Infrastructure.Repositories.Interface;

namespace Resume.Infrastructure.Repositories
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IResumeRepository, ResumeRepository>();
        }
    }
}
