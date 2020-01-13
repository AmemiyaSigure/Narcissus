using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Narcissus.DbModels;
using NLog;
using reCAPTCHA.AspNetCore;

namespace Narcissus
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Logger = LogManager.GetCurrentClassLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ReCaptcha settings.
            services.Configure<RecaptchaSettings>(Configuration.GetSection("ReCaptcha"));
            services.AddTransient<IRecaptchaService, RecaptchaService>();

            RecaptchaService.UseRecaptchaNet = true;

            // Database config.
            services.AddDbContext<NarcissusContext>(option =>
            {
                option.UseMySql($"Server={Configuration["Database:IP"]};Port={Configuration["Database:Port"]};Uid={Configuration["Database:Username"]};Pwd={Configuration["Database:Password"]};DataBase={Configuration["Database:Name"]};");
            });

            services.AddMvc()
                .AddJsonOptions(json =>
                {
                    json.JsonSerializerOptions.IgnoreNullValues = true;
                    json.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    json.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
