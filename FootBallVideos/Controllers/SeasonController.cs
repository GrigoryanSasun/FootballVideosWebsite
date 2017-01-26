using FootballAnalyticsAPI.Models;
using FootBallVideos.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.Controllers
{
    [Route("api/[controller]")]
    public class SeasonController : Controller
    {
        public SeasonController(ISeasonRepository season)
        {
            Season = season;
        }
        public ISeasonRepository Season { get; set; }

        [HttpGet]
        public IEnumerable<Season> GetAll()
        {
            return Season.GetAll();
        }

        [HttpGet("{id}", Name = "GetSeason")]
        public IActionResult GetById(int id)
        {
            var item = Season.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
