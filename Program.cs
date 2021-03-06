using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FootballVideosWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddCommandLine(args)
                        .AddJsonFile("hosting.json", optional: true)
                        .Build();
                        

            var host = new WebHostBuilder()
                .CaptureStartupErrors(true)
                // .UseSetting("detailedErrors", "true")
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
