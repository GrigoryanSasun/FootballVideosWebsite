using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FootballVideosWebsite.Server.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomWebpackDevMiddleware(this IApplicationBuilder app)
        {
            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
                HotModuleReplacement = true
            });
            return app;
        }
        
        public static IApplicationBuilder AddDevMiddlewares(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();
            var loggerFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Startup.Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseCustomWebpackDevMiddleware();
            }

            return app;
        }

        public static IApplicationBuilder AddProductionMiddlewares(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();
            
            if (env.IsProduction())
            {
                app.UseResponseCompression();
            }

            return app;
        }



        // public static IApplicationBuilder SetupMigrations(this IApplicationBuilder app)
        // {
        //     // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
        //     try
        //     {
        //         var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        //         serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        //     }
        //     catch (Exception) { }
        //     return app;
        // }
    }
}
