using Waze_Credit.Utility.AppSettingsClasses;

namespace Waze_Credit.Utility.DI_Config
{
    public static class DI_AppSettingsConfig
    {
        public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TestClass>(configuration.GetSection("TestClass"));
            services.Configure<DatiRuggero>(configuration.GetSection("DatiRuggero"));
            return services;
        }   
    }
}
