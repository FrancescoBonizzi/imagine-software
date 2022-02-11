using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Squidex.ClientLibrary;
using System;
using System.Linq;
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
            services.Configure<SquidexOptions>(Configuration.GetSection("app"));

            services.AddSingleton(c =>
                new SquidexClientManager(c.GetRequiredService<IOptions<SquidexOptions>>().Value));

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/javascript" });
            });

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
            });

            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();
        }

        private const string _contentSecurityPolicyHeaderValue = 
            "default-src 'self'; img-src 'self' admin.imaginesoftware.it; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; font-src 'self'";

        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Remove("Server");

                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "deny");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
                context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");

                context.Response.Headers.Add("Content-Security-Policy", _contentSecurityPolicyHeaderValue);
                context.Response.Headers.Add("X-Content-Security-Policy", _contentSecurityPolicyHeaderValue);
                context.Response.Headers.Add("X-WebKit-CSP", _contentSecurityPolicyHeaderValue);
                await next();
            });

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

            app.UseResponseCompression();
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
