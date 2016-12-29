using System;
using Microsoft.EntityFrameworkCore;

namespace IntitucionWithVisualStudio
{
	public class InstitucionDB : DbContext
	{
		public DbSet<Profesor> Profesores { get; set; }
		//public DbSet<Alumno> Alumnos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

            //services.AddDbContext<InstitucionDB>(options => options.UseMySql("server=192.168.99.100;port=3306;database=PlatziCourse;uid=root;pwd=julio23"));

            optionsBuilder.UseMySql("server=192.168.99.100;port=3306;database=PlatziCourse;uid=root;pwd=julio23");
  //          optionsBuilder.UseSqlite("Filename=.Data.db");
		}
	}
}
