using ImagineSoftwareWebsite.Email;
using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsiteLibrary;
using ImagineSoftwareWebsiteLibrary.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImagineSoftwareWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
            });

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();

            services.AddSingleton<IMyLogger, ConsoleLogger>();
            services.AddSingleton<Configuration>();
            services.AddSingleton<EmailClient>();
        }

        public void Configure(IApplicationBuilder app, IMyLogger myLogger)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });

            app.ConfigureExceptionHandler(myLogger);
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.UseHttpsRedirection();
            app.UseHsts();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    // Tutti i contenuti statici sono versionati, così scarica solo se sono realmente nuovi (immutable)
                    context.Context.Response.Headers.Append("Cache-Control", "public, max-age=31536000, immutable");
                },
                ContentTypeProvider = CustomMiddlewares.GenerateStaticFilesContentProvider()
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseDefaultFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
