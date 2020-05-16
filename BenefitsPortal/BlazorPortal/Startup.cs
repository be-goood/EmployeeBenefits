using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorPortal.Data;
using System.Net.Http;
using BenefitsPortal.Domain.Configurations;
using BenefitsPortal.Services;
using BenefitsPortal.Domain.Interfaces;

namespace BlazorPortal
{
    public class Startup
    {
        private AppSettings _appSettings = new AppSettings();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);
            appSettings.Bind(_appSettings);
            services.AddSingleton<AppSettings>(_appSettings);

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            //services.AddSingleton<EmployeeBenefitsService>();
            services.AddTransient<IEBenefitsRepository>(_ => new EBenefitsRepository(new HttpClient(), _appSettings.ApiGatewayUri));
            //services.AddTransient<IBenefitsRepository>(_ => new BenefitsRepository(new HttpClient(), _apiSettings.MedicalBenefitsApiUri));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
