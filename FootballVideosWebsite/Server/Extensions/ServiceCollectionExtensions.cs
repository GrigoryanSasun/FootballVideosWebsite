using FootballVideosWebsite.Server.Filters;
using FootballVideosWebsite.Server.ModelsData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using FootballVideosWebsite.Server.Models;
using FootBallVideos.Models;
using FootballVideosWebsite.Server.Services;

namespace FootballVideosWebsite.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelValidationFilter));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<FootballWebsiteContext>(options => options.UseSqlServer(configuration.GetConnectionString("FootballWebsiteContext")));
            return services;
        }
        
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ITeamSeasonTournamentMapRepository, TeamSeasonTournamentMapRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<LoggerService>();
            services.AddScoped<FootballWebsiteContext>();
            return services;
        }
    }
}
