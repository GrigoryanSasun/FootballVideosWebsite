using FootBallVideos.Models;
using FootBallVideos.ModelsData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootBallVideos.Controllers
{
    [Route("api/[controller]")]
    public class PlayerParticipiationController : Controller
    {
        public PlayerParticipiationController(IPlayerParticipiationRepository playerParticipiation)
        {
            PlayerParticipation = playerParticipiation;
        }
        public IPlayerParticipiationRepository PlayerParticipation { get; set; }

        [HttpGet]
        public IEnumerable<PlayerParticipation> GetAll()
        {
            return PlayerParticipation.GetAll();
        }

        [HttpGet("{id}", Name = "GetPlayerParticipation")]
        public IActionResult GetById(int id)
        {
            var item = PlayerParticipation.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
