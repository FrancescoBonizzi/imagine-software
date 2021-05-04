using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ImagineSoftwareWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
//#if DEBUG
// Per farlo funzionare in LAN
//                    webBuilder.UseUrls("https://*:5000");
//#endif
                    webBuilder.UseStartup<Startup>();
                });
    }
}
