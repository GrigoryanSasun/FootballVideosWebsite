using FootballAnalyticsAPI.Models;
using FootBallVideos.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        public TeamController(ITeamRepository team)
        {
            Team = team;
        }
        public ITeamRepository Team { get; set; }

        [HttpGet]
        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await Team.GetAllAsync();
        }

        //[HttpGet]
        //public IEnumerable<Team> GetAll()
        //{
        //    return Team.GetAll();
        //}

        [HttpGet("{id}", Name = "GetTeam")]
        public IActionResult GetById(int id)
        {
            var item = Team.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //[HttpGet("{id}", Name = "GetTeam")]
        //public IActionResult GetByIdAsync(int id)
        //{
        //    var item = Team.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}

        [HttpGet("{id}/players", Name = "GetPlayersByTeamId")]
        public async Task<IEnumerable<Players>> GetPlayersByTeamId(int id)
        {
            return await Team.GetPlayersAsync(id);
        }
    }
}
