using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FootballAnalyticsAPI.ModelsData;
using FootballAnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballAnalyticsAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            var connection = @"Server=DESKTOP-EPNJ61I;Database=FootballAnalytics;Trusted_Connection=True;";
            services.AddDbContext<FootballAnalyticsContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IPlayersRepository, PlayersRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<ITournamentRepository, TournamentRepository>();
            services.AddSingleton<ISeasonRepository, SeasonRepository>();
            services.AddSingleton<IPlayerParticipiationRepository, PlayerParticipiationRepository>();
            services.AddSingleton<IMatchRepository, MatchRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseDeveloperExceptionPage();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
