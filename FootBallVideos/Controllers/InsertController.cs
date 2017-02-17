using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootBallVideos.ModelsData;
using FootBallVideos.Models;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FootBallVideos.Controllers
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
            ITeamSeasonTournamentMapRepository map)
        {
            Team = team;
            Tournament = tournament;
            Match = match;
            Player = player;
            Season = season;
            Map = map;
        }

        public ITeamRepository Team { get; set; }
        public ISeasonRepository Season { get; set; }
        public IMatchRepository Match { get; set; }
        public IPlayersRepository Player { get; set; }
        public ITournamentRepository Tournament { get; set; }
        public ITeamSeasonTournamentMapRepository Map { get; set; }

        [HttpPost("tournament", Name = "AddTournament")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Tournaments item)
        {
            if (item == null)
            {
                return false;
            }

            Debug.WriteLine("Tournament : " + item.Name + " - Added");
            return await Tournament.Add(item);
        }

        [HttpPost("team", Name = "AddTeam")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Teams item)
        {
            if (item == null)
            {
                return false;
            }

            Debug.WriteLine("Team : " + item.Name + " - Added");
            return await Team.Add(item);
        }

        [HttpPost("season", Name = "AddSeason")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] SeasonAlternate item)
        {
            if (item == null)
            {
                return false;
            }

            Debug.WriteLine("Season : " + item.Name + " - Added");
            return await Season.Add(item.CovertToSeason());
        }
        
        [HttpPost("player", Name = "AddPlayer")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] Players item)
        {
            if (item == null)
            {
                return false;
            }

            Debug.WriteLine("Player : " + item.Name + " - Added");
            return await Player.Add(item);
        }

        [HttpPost("match", Name = "AddMatch")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] MatchAlternate item)
        {
            if (item == null)
            {
                return false;
            }

            Debug.WriteLine("Match : " + item.Id + " - Added");

            return await Match.Add(item.CovertToMatch());
        }

        [HttpPost("map", Name = "AddMap")]
        [ActionName("Complex")]
        public async Task<bool> Create([FromBody] TeamSeasonTournamentMap item)
        {
            if (item == null)
            {
                return false;
            }

            Debug.WriteLine("Map : " + item.Id + " - Added");
            return await Map.Add(item);
        }

    }
}
