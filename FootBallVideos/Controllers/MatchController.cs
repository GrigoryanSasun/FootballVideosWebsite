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
    public class MatchController : Controller
    {
        public MatchController(IMatchRepository match)
        {
            Match = match;
        }
        public IMatchRepository Match { get; set; }

        [HttpGet]
        public IEnumerable<Match> GetAll()
        {
            return Match.GetAll();
        }

        [HttpGet("{id}", Name = "GetMatch")]
        public IActionResult GetById(int id)
        {
            var item = Match.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
