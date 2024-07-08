using Microsoft.Extensions.DependencyInjection;

namespace Resume.Infrastructure.Repositories
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
