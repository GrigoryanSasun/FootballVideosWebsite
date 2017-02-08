using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootBallVideos.ModelsData;
using FootBallVideos.Models;

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
            ISeasonRepository season )
        {
            Team = team;
            Tournament = tournament;
            Match = match;
            Player = player;
            Season = season;
        }

        public ITeamRepository Team { get; set; }
        public ISeasonRepository Season { get; set; }
        public IMatchRepository Match { get; set; }
        public IPlayersRepository Player { get; set; }
        public ITournamentRepository Tournament { get; set; }

        [HttpPost("tournament", Name = "AddTournament")]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Tournaments item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Tournament.Add(item);
            return CreatedAtRoute("AddTournament", new { id = item.Id }, item);
        }

        [HttpPost("team", Name = "AddTeam")]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Teams item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Team.Add(item);
            return CreatedAtRoute("AddTeams", new { id = item.Id }, item);
        }

        [HttpPost("season", Name = "AddSeason")]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Season item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Season.Add(item);
            return CreatedAtRoute("AddSeason", new { id = item.Id }, item);
        }
        
        [HttpPost("player", Name = "AddPlayer")]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Players item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Player.Add(item);
            return CreatedAtRoute("AddPlayer", new { id = item.Id }, item);
        }

        [HttpPost("match", Name = "AddMatch")]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Matches item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Match.Add(item);
            return CreatedAtRoute("AddMatch", new { id = item.Id }, item);
        }

    }
}
