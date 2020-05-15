using BenefitsApiGateway.Domain.Configurations;
using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net.Http;

namespace BenefitsApiGateway.Api
{
    public class Startup
    {
        private ApiSettings _apiSettings = new ApiSettings();

        private readonly HttpClient _httpclient;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _httpclient = new HttpClient();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("ApiSettings");
            services.Configure<ApiSettings>(appSettings);
            appSettings.Bind(_apiSettings);
            services.AddSingleton<ApiSettings>(_apiSettings);
            services.AddTransient<IEmployeeRepository>(_ => new EmployeeRepository(_httpclient, _apiSettings.EmployeeApiUri));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
