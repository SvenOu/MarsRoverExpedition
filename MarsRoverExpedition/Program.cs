using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MarsRoverExpedition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        [Conditional("DEBUG")]
        protected static void OnInitDebugConfig(WebHostBuilderContext hostingContext, IConfigurationBuilder config)
        {
            config.AddJsonFile("config/appsettings.Development.json");
        }

        [Conditional("RELEASE")]
        protected static void OnInitReleaseConfig(WebHostBuilderContext hostingContext, IConfigurationBuilder config)
        {
            config.AddJsonFile("config/appsettings.json");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        OnInitDebugConfig(hostingContext, config);
                        OnInitReleaseConfig(hostingContext, config);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}