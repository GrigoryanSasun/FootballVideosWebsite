using FootballVideosWebsite.Server.Models;
using FootballVideosWebsite.Server.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace FootballVideosWebsite.Server.Controllers
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
        public IEnumerable<Matches> GetAll()
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

        [HttpPost]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Matches item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Match.Add(item);
            return CreatedAtRoute("GetMatch", new { id = item.Id }, item);
        }
    }
}
