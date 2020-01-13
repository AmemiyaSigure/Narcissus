using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Narcissus
{
    public class Program
    {
        public static readonly string Name = "Narcissus";
        public static readonly string Author = "Amemiya Shigure";
        public static readonly string Version = "1.2.0";

        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Info("Loading...");
            logger.Info($"{Name} version: {Version}!");

            CreateHostBuilder(args).Build().Run();
            LogManager.Shutdown();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureKestrel(kestrel =>
                    {
                        var config = (IConfiguration)kestrel.ApplicationServices.GetService(typeof(IConfiguration));

                        if (bool.Parse(config["Listen:Http:Enable"]))
                        {
                            kestrel.Listen(IPAddress.Any, int.Parse(config["Listen:Http:Port"]), listen =>
                            {
                                listen.UseConnectionLogging();
                            });
                        }

                        if (bool.Parse(config["Listen:Https:Enable"]))
                        {
                            kestrel.Listen(IPAddress.Any, int.Parse(config["Listen:Https:Port"]), listen =>
                            {
                                listen.UseHttps(config["Listen:Https:Cert"], config["Listen:Https:Password"]);
                                listen.UseConnectionLogging();
                            });
                        }
                    });
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Information);
                }).UseNLog();
    }
}
