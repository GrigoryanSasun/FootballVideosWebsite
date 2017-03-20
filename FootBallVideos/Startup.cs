
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FootBallVideos.ModelsData;
using FootBallVideos.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Options;
using FootBallVideos.Elasticsearch;


namespace FootBallVideos
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FootballWebsiteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FootballWebsiteContext")));
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            //var connection = @";Database=FootballAnalytics;Trusted_Connection=True;";
            services.AddSingleton<IPlayersRepository, PlayersRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<ITournamentRepository, TournamentRepository>();
            services.AddSingleton<ISeasonRepository, SeasonRepository>();
            services.AddSingleton<IMatchRepository, MatchRepository>();

            services.AddSingleton<ITeamSeasonTournamentMapRepository, TeamSeasonTournamentMapRepository>();

            services.AddTransient<FootballVideosSearchProvider>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
       

            app.Use(async (context, next) =>
            {
                var insertPath = new PathString("/api/insert");
                if (context.Request.Path.StartsWithSegments(insertPath))
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
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
