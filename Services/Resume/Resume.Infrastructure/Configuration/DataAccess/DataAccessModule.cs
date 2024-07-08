using Base.Domain;
using Microsoft.Extensions.DependencyInjection;
using Resume.Infrastructure.Configuration.DataAccess.Repository;

namespace Resume.Infrastructure.Configuration.DataAccess
{
    public static class DataAccessModuleExtension
    {
        public static void AddDataAccessModule(this IServiceCollection services)
        {
            //services.AddSqlServerDbContext<UserDb>("User");
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

        }
    }
}
