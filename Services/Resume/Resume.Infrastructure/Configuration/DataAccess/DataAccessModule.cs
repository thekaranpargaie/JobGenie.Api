using Base.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Resume.Infrastructure.Configuration.DataAccess.Repository;

namespace Resume.Infrastructure.Configuration.DataAccess
{
    public static class DataAccessModuleExtension
    {
        public static void AddDataAccessModule(this IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__JobGenie");
            services.AddDbContext<ResumeDb>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

        }
    }
}
