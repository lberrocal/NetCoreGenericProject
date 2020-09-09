using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GenericProject
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Exception Running the host");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            return new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.AddConfiguration(config);
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddSerilog();
                })
                .ConfigureServices((hostingContext, services) =>
                {
                });
        }
    }
}
