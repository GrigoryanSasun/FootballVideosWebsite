using FootballAnalyticsAPI.Models;
using FootballAnalyticsAPI.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Controllers
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
        public IEnumerable<Tournaments> GetAll()
        {
            return Tournaments.GetAll();
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
    }
}
