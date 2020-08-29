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
                .GetSection(nameof(ApplicationSettings))
                .GetSection("Security");

            return securitySection.Get<SecuritySettings>();
        }

        public static IServiceCollection AddApplicationSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration
                .GetSection(nameof(ApplicationSettings));

            services.Configure<ApplicationSettings>(applicationSettings);

            return services;
        }
    }
}
