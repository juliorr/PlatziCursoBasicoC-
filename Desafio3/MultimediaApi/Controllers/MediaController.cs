using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultimediaApi.DataAccess;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MultimediaApi.Controllers
{
    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        
        // GET api/media
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var db = new ApiDB();
            db.Database.EnsureCreated();
            
            var result = from media in db.Media
                select media;
                
            List<string> Answer = new List<string>();
            
            foreach (var item in result)
            {
                string Id = $"Id: {item.Id}";
                string Name = $"Media: {item.Name}";
                string Path = $"Path: {item.Path}";
                string Size = "size: XXXX";

                Answer.Append($"{Id}, {Name}, {Path}, {Size}");
            }

            return Answer;
            // return new string[] { "Julio1", "Julio2" };
        }

        // GET api/media/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/media
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/media/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/media/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}