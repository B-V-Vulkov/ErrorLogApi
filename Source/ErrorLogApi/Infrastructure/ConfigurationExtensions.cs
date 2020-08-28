using ErrorLogApi.GlobalConstants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorLogApi.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static SecuritySettings GetSecuritySettings(this IConfiguration configuration)
        {
            var securitySection = configuration
                .GetSection("ApplicationSettings")
                .GetSection("Security");

            //services.Configure<SecuritySettings>(securitySection);

            return securitySection.Get<SecuritySettings>();
        }

        public static IServiceCollection AddTest(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration
                .GetSection("ApplicationSettings");

            services.Configure<ApplicationSettings>(applicationSettings);

            return services;
        }
    }
}
