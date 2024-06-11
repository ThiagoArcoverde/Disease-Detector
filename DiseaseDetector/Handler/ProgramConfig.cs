using DiseaseDetector.Interfaces;
using DiseaseDetector.Services;

namespace DiseaseDetector.Handler
{
    public static class ProgramConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStartupService, StartupService>();
            services.AddScoped<IDiseaseService, DiseaseService>();
            return services;
        }
    }
}
