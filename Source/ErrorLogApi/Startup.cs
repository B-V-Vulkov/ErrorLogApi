namespace ErrorLogApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Infrastructure;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddApplicationSettingsConfiguration(this.configuration)
                .AddJwtAuthentication(this.configuration.GetSecuritySettings())
                .AddDbContext()
                .AddAServices()
                .AddModelMapping()
                .AddControllers(options =>
                {
                    options.SuppressAsyncSuffixInActionNames = false;
                });

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseCors(options => 
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                })
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
    }
}
