using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using bacit_dotnet.MVC.DataAccess; // Adjust to your DataAccess namespace
using bacit_dotnet.MVC.Models; // Adjust to your Models namespace
using System.Configuration;

namespace bacit_dotnet.MVC
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add(
                    "Content-Security-Policy",
                    "default-src 'self'; " +
                    "img-src 'self' ; " +
                    "font-src 'self' ; " +
                    "style-src 'self'; " +
                    "script-src 'self' ; " +
                    "frame-src 'self' ; " +
                    "frame-src 'self' ; " +
                    "connect-src 'self' ; ");
                await next();
            });

            // To enforce HTTPS cnnection
            app.UseHsts();

        }

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure the DbContext for Identity and your application
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(10, 5, 11))));

            // Configure Identity
            services.AddIdentity<Employee, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            // Other services registration, such as your own services, can go here.
        }
    }
}
