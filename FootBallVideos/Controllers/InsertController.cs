using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FootBallVideos.Controllers
{
    [Route("api/[controller]")]
    public class InsertController : Controller
    {

        // POST api/values
        [HttpPost]
        public void Post(string key, [FromBody]string value)
        {

        }
    }
}
