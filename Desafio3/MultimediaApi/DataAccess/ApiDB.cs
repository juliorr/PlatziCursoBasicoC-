using Microsoft.EntityFrameworkCore;
using MultimediaApi.models;

namespace MultimediaApi.DataAccess
{
    public class ApiDB: DbContext
    {
        public DbSet<Media> Media { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Video> Video { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=192.168.99.100;port=3306;database=PlatziCourse;uid=root;pwd=julio23");
        }
    }
}