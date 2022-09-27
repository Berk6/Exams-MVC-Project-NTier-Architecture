using Exams.Service.Mapping;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Exam.Configuration
{
    public static class MapsterConfiguration
    {
        public static IServiceCollection AddMapster(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(UserMappingConfig).Assembly);
            services.AddSingleton(config);
            return services;
        }
    }
}
