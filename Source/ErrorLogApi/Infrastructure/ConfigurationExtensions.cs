namespace ErrorLogApi.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using GlobalConstants;

    public static class ConfigurationExtensions
    {
        public static SecuritySettings GetSecuritySettings(this IConfiguration configuration)
        {
            var securitySection = configuration
                .GetSection("ApplicationSettings")
                .GetSection("Security");

            return securitySection.Get<SecuritySettings>();
        }

        public static IServiceCollection AddApplicationSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration
                .GetSection("ApplicationSettings");

            services.Configure<ApplicationSettings>(applicationSettings);

            return services;
        }
    }
}
