using ImagineSoftwareWebsite.Email;
using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsiteLibrary;
using ImagineSoftwareWebsiteLibrary.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;

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

            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
            services.AddSingleton<IMyLogger, ConsoleLogger>();
            services.AddSingleton<Configuration>();
            services.AddSingleton<EmailClient>();
            services.AddSingleton<RoutesInspector>();
        }

        public void Configure(IApplicationBuilder app, IMyLogger myLogger)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Append("X-Frame-Options", "deny");
                await next();
            });

            app.ConfigureExceptionHandler(myLogger);

            app.UseStatusCodePages(context =>
            {
                int statusCode = context.HttpContext.Response.StatusCode;

                // Non mi piace dover fare il redirect alla pagina degli errori per un not allowed
                if (statusCode != (int)HttpStatusCode.MethodNotAllowed)
                {
                    context.HttpContext.Response.Redirect($"/error/{statusCode}");
                }

                return Task.CompletedTask;
            });

            app.UseHttpsRedirection();
            app.UseHsts();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    // Posso cachare per sempre tutti i contenuti statici perché sono versionati, così li scarica solo se sono realmente nuovi (immutable)
                    context.Context.Response.Headers.Append("Cache-Control", "public, max-age=31536000, immutable");
                },
                ContentTypeProvider = CustomMiddlewares.GenerateStaticFilesContentProvider()
            });

            app.UseRouting();
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
