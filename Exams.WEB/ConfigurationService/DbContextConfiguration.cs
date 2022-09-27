using Exams.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Exam.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), opts =>
                {
                    opts.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
            return services;
        }
    }
}
