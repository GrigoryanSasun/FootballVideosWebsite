using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FootballVideosWebsite.Server.Extensions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
//using AspNetCoreSpa.Server;

namespace FootballVideosWebsite
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnv;
        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                           .SetBasePath(env.ContentRootPath)
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                           .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            if (_hostingEnv.IsProduction())
            {
                services.AddGzipCompression();
            }

            services.AddCustomDbContext(Configuration);

            services.RegisterCustomServices(Configuration);

            services.AddCustomizedMvc();

            // Node services are to execute any arbitrary nodejs code from .net
            services.AddNodeServices();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.AddDevMiddlewares();

            app.AddProductionMiddlewares();

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                List<PathString> securePaths = new List<PathString>();
                securePaths.Add(new PathString("/api/insert"));
                if (securePaths.Contains(context.Request.Path))
                {
                    var key = Configuration.GetValue<string>("MySettings:ApiKey");
                    var headerKey = context.Request.Headers["ApiKey"];
                    if (string.Compare(key, headerKey, false) == 0)
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("Go f**k yourself");
                    }
                }
                else
                {
                    await next.Invoke();
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
