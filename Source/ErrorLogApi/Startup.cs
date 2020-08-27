namespace ErrorLogApi
{
    using AutoMapper;
    using ErrorLogApi.Data;
    using ErrorLogApi.GlobalConstants;
    using ErrorLogApi.Infrastructure;
    using ErrorLogApi.Services;
    using ErrorLogApi.Services.Contracts;
    using ErrorLogApi.Services.Infrastructure;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var securitySection = this.configuration
                .GetSection("ApplicationSettings")
                .GetSection("Security");

            services.Configure<SecuritySettings>(securitySection);

            var securitySettings = securitySection.Get<SecuritySettings>();

            var key = Encoding.UTF8.GetBytes(securitySettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
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

            services.Configure<ApplicationSettings>(
                this.configuration.GetSection("ApplicationSettings"));

            services.AddAutoMapper(
                typeof(ControllerMappingProfile).Assembly,
                typeof(ServiceMappingProfile).Assembly);

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IErrorLogService, ErrorLogService>();
            services.AddScoped<IErrorLogDbContext, ErrorLogDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
