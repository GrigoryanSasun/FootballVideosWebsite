using FootBallVideos.Models;
using FootBallVideos.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootBallVideos.Controllers
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
            try
            {
                return Season.GetAll();
            }
            catch (System.Exception ex)
            {

                throw;
            }
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

        [HttpPost]
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
    }
}
