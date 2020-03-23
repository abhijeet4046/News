using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using News.Model.NewsService;

namespace News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsHubController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsHubController(INewsService newsService)
        {
            _newsService = newsService;
        }
        // GET: api/NewsHub
        [HttpGet]
        public IEnumerable<Model.News> Get()
        {
            return _newsService.GetAllNews();
        }

        [HttpGet]
        [Route("Pages")]
        public IEnumerable<Model.NewsPage> GetNewsPages()
        {
            return _newsService.GetNewsPages();
        }


        // GET: api/NewsHub/5
        [HttpGet("{id}", Name = "Get")]
        public Model.News Get(int id)
        {
            return _newsService.GetAllNews().FirstOrDefault(x => x.NewsId.Equals(id));
        }

        // POST: api/NewsHub
        [HttpPost]
        public IActionResult Post([FromBody] Model.News news)
        {
            if (news == null)
            {
                return BadRequest("News is null.");
            }
            _newsService.SubmitNews(news);
            return Ok();
        }

        // PUT: api/NewsHub/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _newsService.DeleteNews(Get(id));
        }
    }
}
