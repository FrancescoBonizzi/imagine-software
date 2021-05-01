using ImagineSoftwareWebsiteLibrary.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Net;

namespace ImagineSoftwareWebsite.HttpLifecycle
{
    public static class CustomMiddlewares
    {
        public static FileExtensionContentTypeProvider GenerateStaticFilesContentProvider()
        {
            var provider = new FileExtensionContentTypeProvider();

            // Queste definizioni sono più corrette di quelle di default, secondo Mozilla
            provider.Mappings[".css"] = "text/css; charset=utf-8";
            provider.Mappings[".js"] = "text/javascript; charset=utf-8";
            provider.Mappings[".ttf"] = "font/ttf";
            provider.Mappings[".ico"] = "image/x-icon";
            provider.Mappings[".svg"] = "image/svg+xml";
            provider.Mappings[".ttf"] = "application/x-font-ttf";
            provider.Mappings[".woff"] = "application/x-font-woff";
            provider.Mappings[".eot"] = "application/vnd.ms-fontobject";

            return provider;
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IMyLogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    try
                    {
                        // Loggo sempre l'errore
                        IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        await logger.Log(contextFeature.Error);

                        // Se è una chiamata alle API, ritorno un errore da API, non una pagina intera
                        if (context.Request.Path.StartsWithSegments(
                            new PathString($"/{Definitions.CONTROLLER_API_ROUTE_NAME}"),
                            StringComparison.InvariantCultureIgnoreCase))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            // ...e solo il messaggio dell'eccezione, non tutta la stack trace
                            await context.Response.WriteAsync(contextFeature.Error.Message);
                        }
                        else
                        {
                            // Altrimenti ritorno una pagina intera
                            context.Response.Redirect("/Home/StatusCodeError?code=500");
                        }
                    }
                    catch (Exception ex)
                    {
                        await logger.Log(ex);
                    }
                });
            });
        }
    }
}
