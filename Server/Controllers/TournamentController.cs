using FootballVideosWebsite.Server.Models;
using FootballVideosWebsite.Server.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        public TournamentController(ITournamentRepository tournaments)
        {
            Tournaments = tournaments;
        }
        public ITournamentRepository Tournaments { get; set; }

        [HttpGet]
        public async Task<IEnumerable<Tournaments>> GetAllAsync()
        {
            return await Tournaments.GetAllAsync();
        }

        [HttpGet("{id}", Name = "GetTournaments")]
        public IActionResult GetById(int id)
        {
            var item = Tournaments.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("{id}/teams", Name = "GetTeamsByTournamentId")]
        public async Task<IEnumerable<Teams>> GetPlayersByTeamId(int id)
        {
            return await Tournaments.GetTeamsAsync(id);
        }

        //[HttpGet("{id}/teams", Name = "GetTeamsByTournamentId")]
        //public IEnumerable<Teams> GetPlayersByTeamId(int id)
        //{
        //    return Tournaments.GetTeams(id);
        //}

        [HttpPost]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Tournaments item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Tournaments.Add(item);
            return CreatedAtRoute("AddTournament", new { id = item.Id }, item);
        }
    }
}
