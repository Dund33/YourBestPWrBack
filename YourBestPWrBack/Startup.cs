using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using YourBestPWrBack.Services;

namespace YourBestPWrBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var path = File.ReadAllText("Properties/CosmosPath.txt");
            services.AddControllers();
            services.AddSingleton<IUserRepo, MockUserRepo>();
            services.AddSingleton<IAuthRepo, SimpleAuthRepo>();
            services.AddSingleton<ILecturerRepo, LecturerRepo>(provider => new LecturerRepo(path));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy =>
            policy.WithOrigins("https://localhost:44315/*")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
            });
        }
    }
}
