namespace ErrorLogApi.Infrastructure
{
    using System;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;

    using Data;
    using Services;
    using Services.Contracts;
    using Services.Infrastructure;
    using GlobalConstants;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
            => services.AddScoped<IErrorLogDbContext, ErrorLogDbContext>();

        public static IServiceCollection AddModelMapping(this IServiceCollection services)
            => services.AddAutoMapper(
                typeof(ControllerMappingProfile).Assembly,
                typeof(ServiceMappingProfile).Assembly);

        public static IServiceCollection AddAServices(this IServiceCollection services)
            => services
                .AddScoped<IJwtService, JwtService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IErrorLogService, ErrorLogService>();

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, SecuritySettings securitySettings)
        {
            var key = Encoding.UTF8.GetBytes(securitySettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
