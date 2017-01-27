using FootBallVideos.Models;
using FootBallVideos.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Controllers
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
        public async Task<IEnumerable<TournamentDetail>> GetAllAsync()
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
        public async Task<IEnumerable<Team>> GetPlayersByTeamId(int id)
        {
            return await Tournaments.GetTeamsAsync(id);
        }
    }
}
