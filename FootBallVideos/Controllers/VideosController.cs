using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootBallVideos.Models;
using FootBallVideos.ModelsData;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FootBallVideos.Controllers
{
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        public VideosController(IVideoRepository videos)
        {
            Videos = videos;
        }
        public IVideoRepository Videos { get; set; }

        [HttpGet]
        public async Task<IEnumerable<Videos>> GetAllAsync()
        {
            return await Videos.GetAllAsync();
        }

        [HttpGet("{id}", Name = "GetVideos")]
        public IActionResult GetById(int id)
        {
            var item = Videos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("Tournaments/{id}", Name = "GetVideosByTournamentId")]
        public async Task<IEnumerable<Videos>> GetVideosByTournamentId(int id)
        {
            return await Videos.GetVideosByTournamentIdAsync(id);
        }

        [HttpGet("Team/{id}", Name = "GetVideosByTournamentId")]
        public async Task<IEnumerable<Videos>> GetVideosByTeamID(int id)
        {
            return await Videos.GetVideosByTeamIdAsync(id);
        }

        [HttpGet("Player/{id}", Name = "GetVideosByTournamentId")]
        public async Task<IEnumerable<Videos>> GetVideosByPlayerId(int id)
        {
            return await Videos.GetVideosByPlayerIdAsync(id);
        }


        [HttpPost]
        [ActionName("Complex")]
        public IActionResult Create([FromBody] Videos item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Videos.Add(item);
            return CreatedAtRoute("AddVideos", new { id = item.Id }, item);
        }
    }
}
