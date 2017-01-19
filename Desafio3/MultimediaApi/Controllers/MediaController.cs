using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultimediaApi.DataAccess;
using System.Linq;
using MultimediaApi.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultimediaApi.Controllers
{
    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        
        // GET api/media
        [HttpGet]
        public string Get()
        {
            var db = new ApiDB();
            db.Database.EnsureCreated();
            
            var result = from media in db.Media
                select media;

            return JsonConvert.SerializeObject(result);    
        }

        // GET api/media/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var db = new ApiDB();
            db.Database.EnsureCreated();

            var result = from media in db.Media
                              where media.Id.Equals(id)
                              select media;
            return JsonConvert.SerializeObject(result);
        }

        // POST api/media
        [HttpPost]
        public IEnumerable<string> Post([FromBody]Media newValue)
        {
            var db = new ApiDB();
            db.Database.EnsureCreated();
            db.Media.Add(newValue);
            db.SaveChanges();
        
            return new string[] {"Done"};
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