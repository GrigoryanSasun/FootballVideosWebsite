using FootballVideosWebsite.Server.Elasticsearch;
using Microsoft.AspNetCore.Mvc;


namespace FootballVideosWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    public class FootballVideosElasticsearchController : Controller
    {
        private readonly FootballVideosSearchProvider _footballVideosSearchProvider;

        public FootballVideosElasticsearchController(FootballVideosSearchProvider footballVideosSearchProvider)
        {
            _footballVideosSearchProvider = footballVideosSearchProvider;
        }

        //[HttpGet("search/{from}/{searchtext}")]
        //public IActionResult Search(string searchtext, int from)
        //{
        //    return Ok(_footballVideosSearchProvider.Search(searchtext.ToLower(), from));
        //}

        [HttpGet("querystringsearch/{searchtext}")]
        public IActionResult QueryString(string searchtext)
        {
            return Ok(_footballVideosSearchProvider.QueryString(searchtext));
        }

        [HttpGet("autocomplete/{searchtext}")]
        public IActionResult AutoComplete(string searchtext)
        {
            return Ok(_footballVideosSearchProvider.AutocompleteSearch(searchtext.ToLower()));
        }

        [HttpGet("createindex")]
        public IActionResult CreateIndex()
        {
            _footballVideosSearchProvider.CreateIndex();
            return Ok("index created");
        }

        [HttpGet("createdata")]
        public IActionResult CreateTestData()
        {
            _footballVideosSearchProvider.CreateData();
            return Ok("test data created");
        }

        [HttpGet("indexexists")]
        public IActionResult GetElasticsearchStatus()
        {
            return Ok(_footballVideosSearchProvider.GetStatus());
        }
    }
}
