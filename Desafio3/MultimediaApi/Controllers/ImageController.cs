using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultimediaApi.DataAccess;
using System.Linq;
using MultimediaApi.models;
using Newtonsoft.Json;

namespace MultimediaApi.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private ApiDB db;

        private void InitDB()
        {
            if (this.db == null) { 
                this.db = new ApiDB();
                this.db.Database.EnsureCreated();
            }
        }

        // GET api/image
        [HttpGet]
        public string Get()
        {
            InitDB();
            
            var result = from image in this.db.Image
                select image;

            return JsonConvert.SerializeObject(result);    
        }

        // GET api/image/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result = GetImageByID(id);
            if (result.Count() > 0) {
                return JsonConvert.SerializeObject(result);
            } else {
                string[] NoItem = new string[]  {"The id does not exist"};
                return JsonConvert.SerializeObject(NoItem);
            }
        }

        // POST api/image
        [HttpPost]
        public IEnumerable<string> Post([FromBody]Image newValue)
        {
            InitDB();
            this.db.Image.Add(newValue);
            this.db.SaveChanges();
        
            return new string[] {"Done"};
        }

        // PUT api/image/5
        [HttpPut("{id}")]
        public IEnumerable<string> Put(int id, [FromBody]Image newValue)
        {
            InitDB();

            var result = GetImageByID(id);
            if (result.Count() == 1) {
                newValue.Id = id;
                this.db.Image.Update(newValue);
                this.db.SaveChanges();
                return new string[] {"Done"};
            } else {
                return new string[] {"The id does not exist"};
            }
        }

        // DELETE api/image/5
        [HttpDelete("{id}")]
        public IEnumerable<string> Delete(int id)
        {
            InitDB();
            var result = GetImageByID(id);
            if (result.Count() == 1) {
                Image ImageToDele = new Image(){Id = id};
               
                this.db.Image.Remove(ImageToDele);
                this.db.SaveChanges();
                return new string[] {"Done"};
            } else {
                return new string[] {"The id does not exist"};
            }
        }

        private IQueryable<Image> GetImageByID(int id)
        {
            InitDB();
            this.db.Database.EnsureCreated();
            
            var result = from image in this.db.Image
                              where image.Id.Equals(id)
                              select image;

            return result;
        }
    }
}