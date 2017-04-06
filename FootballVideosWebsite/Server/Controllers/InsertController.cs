using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballVideosWebsite.Server.ModelsData;
using FootballVideosWebsite.Server.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballVideosWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    public class InsertController : Controller
    {
        public InsertController(            
            ITeamRepository team, 
            ITournamentRepository tournament, 
            IMatchRepository match, 
            IPlayersRepository player, 
            ISeasonRepository season,
            ITeamSeasonTournamentMapRepository map,
            IVideoRepository video)
        {
            Team = team;
            Tournament = tournament;
            Match = match;
            Player = player;
            Season = season;
            Map = map;
            Video = video;
        }

        public ITeamRepository Team { get; set; }
        public ISeasonRepository Season { get; set; }
        public IMatchRepository Match { get; set; }
        public IPlayersRepository Player { get; set; }
        public ITournamentRepository Tournament { get; set; }
        public ITeamSeasonTournamentMapRepository Map { get; set; }
        public IVideoRepository Video { get; set; }

        [HttpPost("tournament", Name = "AddTournament")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Tournaments item)
        {
            if (item == null)
            {
                return false;
            }

            return await Tournament.AddAsync(item);
        }

        [HttpPost("team", Name = "AddTeam")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Teams item)
        {
            if (item == null)
            {
                return false;
            }
            return await Team.AddAsync(item);
        }

        [HttpPost("season", Name = "AddSeason")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] SeasonAlternate item)
        {
            if (item == null)
            {
                return false;
            }
            return await Season.AddAsync(item.CovertToSeason());
        }
        
        [HttpPost("player", Name = "AddPlayer")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Players item)
        {
            if (item == null)
            {
                return false;
            }
            return await Player.AddAsync(item);
        }

        [HttpPost("match", Name = "AddMatch")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] MatchAlternate item)
        {
            if (item == null)
            {
                return false;
            }
            return await Match.AddAsync(item.CovertToMatch());
        }

        [HttpPost("map", Name = "AddMap")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] TeamSeasonTournamentMap item)
        {
            if (item == null)
            {
                return false;
            }
            return await Map.AddAsync(item);
        }

        [HttpPost("video", Name = "AddVideos")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Videos item)
        {
            if (item == null)
            {
                return false;
            }
            return await Video.AddAsync(item);
        }

    }
}
