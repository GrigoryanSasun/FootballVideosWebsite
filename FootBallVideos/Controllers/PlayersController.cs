using FootBallVideos.Models;
using FootBallVideos.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootBallVideos.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        public PlayersController(IPlayersRepository players)
        {
            Players = players;
        }
        public IPlayersRepository Players { get; set; }

        [HttpGet]
        public IEnumerable<Players> GetAll()
        {
            return Players.GetAll();
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public IActionResult GetById(int id)
        {
            var item = Players.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
