using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FAnalyticsAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FAnalyticsAPI.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        public VideoController(IVideoRepository todoItems)
        {
            VideoItems = todoItems;
        }
        public IVideoRepository VideoItems { get; set; }

        [HttpGet]
        public IEnumerable<VideoItem> GetAll()
        {
            return VideoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetVideo")]
        public IActionResult GetById(string id)
        {
            var item = VideoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VideoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            VideoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] VideoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = VideoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            VideoItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = VideoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            VideoItems.Remove(id);
            return new NoContentResult();
        }
    }
}
