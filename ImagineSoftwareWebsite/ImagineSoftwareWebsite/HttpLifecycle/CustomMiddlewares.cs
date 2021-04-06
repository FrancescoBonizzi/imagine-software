﻿using Microsoft.AspNetCore.StaticFiles;

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

            return provider;
        }
    }
}
