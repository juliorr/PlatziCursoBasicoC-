using System.Collections.Generic;
using IntitucionWithVisualStudio;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{


	public static void Main(string[] args)
	{
        System.Console.WriteLine(args);
		var db = new InstitucionDB();
		db.Database.EnsureCreated();

		//List<Profesor> Profesores = CrearLista();

  //      db.Profesores.AddRange(Profesores);
  //      db.SaveChanges();

        //var subconjunto = from prof in db.Profesores
        //                  where prof.Nombre.StartsWith("J")
        //                  select prof;


        //foreach (var item in subconjunto)
        //{
        //          item.CodigoInterno = "STARTS_WITH_J";
        //          System.Console.WriteLine($"Nombre {item.Nombre}");
        //          db.Update(item);

        //}
        //db.SaveChanges();

        //System.Console.WriteLine("Cuantos profesores con L hay" + 
        //                         db.Profesores.Where((p) => p.Nombre.StartsWith("L")).Count());
        //var profesoresBorrable = from p in db.Profesores
        //                          where p.Nombre == "Pedro"
        //                          select p;
        //if (profesoresBorrable.FirstOrDefault() != null)
        //{
        //    db.Profesores.Remove(profesoresBorrable.FirstOrDefault());
        //    db.SaveChanges();
        //}

        System.Console.ReadLine();
	}

	private static List<Profesor> CrearLista()
	{
		List<Profesor> Profesores = new List<Profesor>();
		Profesores.Add(new Profesor() { Nombre = "Juan" });
		Profesores.Add(new Profesor() { Nombre = "Pedro" });
		Profesores.Add(new Profesor() { Nombre = "Julio" });
		Profesores.Add(new Profesor() { Nombre = "Ana" });
		Profesores.Add(new Profesor() { Nombre = "Liliana" });
		Profesores.Add(new Profesor() { Nombre = "Hilda" });
		Profesores.Add(new Profesor() { Nombre = "Fernando" });
		Profesores.Add(new Profesor() { Nombre = "Ulises" });
		Profesores.Add(new Profesor() { Nombre = "Luis" });
		Profesores.Add(new Profesor() { Nombre = "Carlos" });
		Profesores.Add(new Profesor() { Nombre = "Edna" });
		Profesores.Add(new Profesor() { Nombre = "Mateo" });
		Profesores.Add(new Profesor() { Nombre = "Jesus" });
		Profesores.Add(new Profesor() { Nombre = "Marcos" });
		Profesores.Add(new Profesor() { Nombre = "Efrain" });
		return Profesores;
	}
}
