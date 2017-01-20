using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultimediaApi.DataAccess;
using System.Linq;
using MultimediaApi.models;
using Newtonsoft.Json;

namespace MultimediaApi.Controllers
{
    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        private ApiDB db;

        private void InitDB()
        {
            if (this.db == null) { 
                this.db = new ApiDB();
                this.db.Database.EnsureCreated();
            }
        }

        // GET api/media
        [HttpGet]
        public string Get()
        {
            InitDB();
            
            var result = from media in this.db.Media
                select media;

            return JsonConvert.SerializeObject(result);    
        }

        // GET api/media/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result = GetMediaByID(id);
            if (result.Count() > 0) {
                return JsonConvert.SerializeObject(result);
            } else {
                string[] NoItem = new string[]  {"The id does not exist"};
                return JsonConvert.SerializeObject(NoItem);
            }
        }

        // POST api/media
        [HttpPost]
        public IEnumerable<string> Post([FromBody]Media newValue)
        {
            InitDB();
            this.db.Media.Add(newValue);
            this.db.SaveChanges();
        
            return new string[] {"Done"};
        }

        // PUT api/media/5
        [HttpPut("{id}")]
        public IEnumerable<string> Put(int id, [FromBody]Media newValue)
        {
            InitDB();

            var result = GetMediaByID(id);
            if (result.Count() == 1) {
                
                newValue.Id = id;
                this.db.Media.Update(newValue);
                this.db.SaveChanges();
                return new string[] {"Done"};
            } else {
                return new string[] {"The id does not exist"};
            }
        }

        // DELETE api/media/5
        [HttpDelete("{id}")]
        public IEnumerable<string> Delete(int id)
        {
            InitDB();
            var result = GetMediaByID(id);
            if (result.Count() == 1) {
                Media MediaToDele = new Media(){Id = id};
               
                this.db.Media.Remove(MediaToDele);
                this.db.SaveChanges();
                return new string[] {"Done"};
            } else {
                return new string[] {"The id does not exist"};
            }
        }

        private IQueryable<Media> GetMediaByID(int id)
        {
            InitDB();
            this.db.Database.EnsureCreated();
            
            var result = from media in this.db.Media
                              where media.Id.Equals(id)
                              select media;

            return result;
        }
    }
}