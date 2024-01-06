using Microsoft.EntityFrameworkCore;
using UrlShortenerWebApp.Models;

namespace UrlShortenerWebApp {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddDbContext<UrlShortenerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=UrlShortener}/{action=Index}/{id?}");
            });
        }
    }
}