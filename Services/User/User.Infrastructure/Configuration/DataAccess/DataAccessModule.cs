using Base.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Infrastructure.Configuration.DataAccess.Repository;

namespace User.Infrastructure.Configuration.DataAccess
{
    public static class DataAccessModuleExtension
    {
        public static void AddDataAccessModule(this IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__JobGenie");
            services.AddDbContext<UserDb>(options =>
                options.UseSqlServer(connectionString),ServiceLifetime.Scoped);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

        }
    }
}
