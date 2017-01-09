using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Institucion.DataAccess;
using Institucion.Misc;
using Institucion.Models;
using Microsoft.Extensions.DependencyInjection;
using Models.Institucion;
using System.Linq;

namespace Institucion
{
    public class Program
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InstitucionDB>();
        }

        public static void Main(string[] args)
        {
            // Ancho
            // Largo
            // Bits per pixel
            FileStream imagen = new FileStream("./Files/cool.bmp", FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(imagen);
            byte[] buffer = new byte[16];

            binaryReader.BaseStream.Position = 17;
            binaryReader.BaseStream.Read(buffer, 0, 16);

            imagen.Dispose();
            binaryReader.Dispose();

            byte[] anchoBytes = new byte[4] {buffer[0], buffer[1], buffer[2], buffer[3]};
            byte[] largoBytes = new byte[4] {buffer[4], buffer[5], buffer[6], buffer[7]};
            byte[] bitCountBytes = new byte[2] {buffer[10], buffer[11]};

            int ancho = GetTheValuerray(anchoBytes);
            int largo = GetTheValuerray(largoBytes);
            int bitCount = GetTheValuerray(bitCountBytes);


            System.Console.WriteLine($"Ancho: {ancho}, Largo: {largo}, bits per pixel: {GetBitsPerPixel(bitCount)} ");
        }

        private static string GetBitsPerPixel(int bitCountPerPixel)
        {
            string bitPerPixel = "NONE";

            switch (bitCountPerPixel)
            {
                case 1:
                    bitPerPixel = "Monocramatic";
                    break;
                case 4:
                    bitPerPixel = "4 bit palletixed";
                    break;
                case 8:
                    bitPerPixel = "8 bit palletixed";
                    break;
                case 16:
                    bitPerPixel = "16 bit RGB";
                    break;
                case 24:
                    bitPerPixel = "24 bit RGB";
                    break;

            }

            return bitPerPixel;
        }

        private static int GetTheValuerray(byte[] ArrayToCheck)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(ArrayToCheck);
            }

            return BitConverter.ToInt16(ArrayToCheck, 0);
        }

        public void Desafio1()
        {
            FileStream fileProfesores = new FileStream("./Files/profesBinarios.bin", FileMode.Open);
            var binaryReader = new BinaryReader(fileProfesores);
            List<Profesor> listProfesores = new List<Profesor>();

            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                listProfesores.Add(new Profesor() { Nombre = binaryReader.ReadString(), Id = binaryReader.ReadInt32() });
            }

            fileProfesores.Dispose();
            binaryReader.Dispose();

            foreach (var item in listProfesores)
            {
                System.Console.WriteLine(item.Id);
                System.Console.WriteLine(item.Nombre);
            }
        }

        private void Rutina9()
        {
            Random rnd = new Random();
            // var listaProfesores = CrearLista();
            Profesor[] listaProfesores = new Profesor[10] {
                new Profesor() { Nombre = "Juan", Id = rnd.Next() },
                new Profesor() { Nombre = "Pedro", Id = rnd.Next() },
                new Profesor() { Nombre = "Julio", Id = rnd.Next() },
                new Profesor() { Nombre = "Ana", Id = rnd.Next() },
                new Profesor() { Nombre = "Liliana", Catedra = "Marketing", Id = rnd.Next() },
                new Profesor() { Nombre = "Hilda", Id = rnd.Next() },
                new Profesor() { Nombre = "Fernando", Id = rnd.Next() },
                new Profesor() { Nombre = "Ulises", Catedra = "Marketing", Id = rnd.Next() },
                new Profesor() { Nombre = "Luis", Id = rnd.Next() },
                new Profesor() { Nombre = "Carlos", Id = rnd.Next() }
            };

            var consulta = from profe in listaProfesores
                           where profe.Catedra == "Marketing"
                           || profe.Nombre.StartsWith("J")
                           select new
                           {
                               IDProfesor = profe.Id,
                               Nombre = profe.Nombre.ToUpper(),
                               Llave = Guid.NewGuid().ToString()
                           };
            foreach (var item in consulta)
            {
                System.Console.WriteLine($"IDProfesor =  {item.IDProfesor} - Nombre = {item.Nombre} - Llave = {item.Llave}");
            }
        }
        private void Rutina8()
        {
            var db = new InstitucionDB();
            db.Database.EnsureCreated();

            List<Profesor> Profesores = CrearLista();

            db.Profesores.AddRange(Profesores);
            db.SaveChanges();

            var subconjunto = from prof in db.Profesores
                              where prof.Nombre.StartsWith("J")
                              select prof;


            foreach (var item in subconjunto)
            {
                item.CodigoInterno = "STARTS_WITH_J";
                System.Console.WriteLine($"Nombre {item.Nombre}");
                db.Update(item);

            }
            db.SaveChanges();

            System.Console.WriteLine("Cuantos profesores con L hay " +
                                     db.Profesores.Where((p) => p.Nombre.StartsWith("L")).Count());
            var profesoresBorrable = from p in db.Profesores
                                     where p.Nombre == "Pedro"
                                     select p;
            if (profesoresBorrable.FirstOrDefault() != null)
            {
                db.Profesores.Remove(profesoresBorrable.FirstOrDefault());
                db.SaveChanges();
            }
        }

        private static List<Profesor> CrearLista()
        {
            List<Profesor> Profesores = new List<Profesor>();
            Profesores.Add(new Profesor() { Nombre = "Juan" });
            Profesores.Add(new Profesor() { Nombre = "Pedro" });
            Profesores.Add(new Profesor() { Nombre = "Julio" });
            Profesores.Add(new Profesor() { Nombre = "Ana" });
            Profesores.Add(new Profesor() { Nombre = "Liliana", Catedra = "Marketing" });
            Profesores.Add(new Profesor() { Nombre = "Hilda" });
            Profesores.Add(new Profesor() { Nombre = "Fernando" });
            Profesores.Add(new Profesor() { Nombre = "Ulises", Catedra = "Marketing" });
            Profesores.Add(new Profesor() { Nombre = "Luis" });
            Profesores.Add(new Profesor() { Nombre = "Carlos" });
            Profesores.Add(new Profesor() { Nombre = "Edna" });
            Profesores.Add(new Profesor() { Nombre = "Mateo" });
            Profesores.Add(new Profesor() { Nombre = "Jesus", Catedra = "Marketing" });
            Profesores.Add(new Profesor() { Nombre = "Marcos" });
            Profesores.Add(new Profesor() { Nombre = "Efrain" });
            return Profesores;
        }

        private void Rutina7()
        {
            List<Profesor> listaProfes = new List<Profesor>();
            string[] lineas = File.ReadAllLines("./Files/Profesores.txt");
            int localId = 0;

            foreach (var linea in lineas)
            {
                listaProfes.Add(new Profesor() { Nombre = linea, Id = localId++ });
            }

            foreach (Profesor profesor in listaProfes)
            {
                System.Console.WriteLine(profesor.Nombre);
            }

            FileStream archivo = File.Open("./Files/profesBinarios.bin", FileMode.OpenOrCreate);
            BinaryWriter binaryFile = new BinaryWriter(archivo);

            foreach (Profesor profesor in listaProfes)
            {
                byte[] bytesNombre = Encoding.UTF8.GetBytes(profesor.Nombre);
                binaryFile.Write(profesor.Nombre);
                binaryFile.Write(profesor.Id);
            }

            binaryFile.Dispose();
            archivo.Dispose();
        }

        private static string formatter(string input)
        {
            byte[] stringBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(stringBytes);
        }

        private static void Tranmisor_InformacionEnviada(object sender, EventArgs e)
        {
            System.Console.WriteLine("TRANSMISION DE MI INFORMACION");
        }

        private void Rutina6()
        {
            var profesor = new Profesor() { Id = 1, Nombre = "Mateo", Appellido = "Perez", CodigoInterno = "PROFE_SMART" };
            var transmisor = new TransmisorDeDatos();
            transmisor.InformacionEnviada += Tranmisor_InformacionEnviada;
            transmisor.InformacionEnviada += (obj, evtarg) =>
                {
                    System.Console.WriteLine("WOOOOAAAAAAAA");
                };

            transmisor.FormatearYEnviar(profesor,
                (s) =>
                {
                    byte[] stringBytes = Encoding.UTF8.GetBytes(s);
                    return Convert.ToBase64String(stringBytes);
                }
            , "JULIORR");

            transmisor.InformacionEnviada -= Tranmisor_InformacionEnviada;
            transmisor.FormatearYEnviar(profesor, formatter, "JULIORR");
        }

        private void Rutina5()
        {
            IList<Persona> listaPersonas = new List<Persona>();
            listaPersonas.Add(new Alumno("Pedro 2", "Fernandez") { NickName = "Pedrito" });
            listaPersonas.Add(new Alumno("Pedro", "Fernandez") { NickName = "Pedrito 2" });
            listaPersonas.Add(new Profesor() { Nombre = "Matematicas", Appellido = "Avanzada" });
            listaPersonas.Add(new Alumno("Ginac", "Guigui"));
            listaPersonas.Add(new Profesor() { Nombre = "Fisica", Appellido = "Principios" });
            listaPersonas.Add(new Alumno("Alberto", "Piedra"));

            foreach (var obj in listaPersonas)
            {
                if (obj is Alumno)
                {
                    var al = (Alumno)obj;
                    System.Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                }
                else
                {
                    var per = obj as Persona;
                    if (per != null)
                    {
                        System.Console.WriteLine(per.NombreCompleto);
                    }
                }
            }
        }

        private void Rutina4()
        {
            Persona[] arregloPersonas = new Persona[5];
            var tamano = arregloPersonas.Length;

            arregloPersonas[0] = new Alumno("Pedro", "Fernandez") { NickName = "Pedrito" };
            arregloPersonas[1] = new Profesor() { Nombre = "Matematicas", Appellido = "Avanzada" };
            arregloPersonas[2] = new Alumno("Ginac", "Guigui");
            arregloPersonas[3] = new Profesor() { Nombre = "Fisica", Appellido = "Principios" };
            arregloPersonas[4] = new Alumno("Alberto", "Piedra");

            for (int i = 0; i < arregloPersonas.Length; i++)
            {
                if (arregloPersonas[i] is Alumno)
                {
                    var al = (Alumno)arregloPersonas[i];
                    System.Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                }
                else
                {
                    System.Console.WriteLine(arregloPersonas[0].NombreCompleto);
                }
            }
        }

        private void Rutina3()
        {
            var alumno = new Alumno(
                "Julio",
                "Rodriguez"
            )
            {
                Estado = EstadosAlumno.Activo,
                NickName = "Cotorro",
                Email = "juliorr@gmail.com"
            };
            var profesor = new Profesor();
            Persona persona = profesor;

            alumno = (Alumno)persona;

            if (persona is Profesor)
            {
                var profe = (Profesor)persona;
            }

            var tmpProfesor = persona as Profesor;

            if (tmpProfesor != null)
            {

            }
        }

        private void Rutina2()
        {
            short s = 32000;
            int i = 33000;
            float f = 2.35f;

            Console.WriteLine(i);
            s = (short)i;
            Console.WriteLine(s);
            System.Console.WriteLine(f);
            i = (int)f;
            System.Console.WriteLine(i);
        }
        private void Rutina1()
        {
            Console.WriteLine("GESTION DE INSTITUCION");

            Persona[] lista = new Persona[3];


            lista[0] = new Alumno("Juan Carlos", "Rodriguez") { Id = 1, Edad = 35, Telefono = "6622449388", Email = "juliorr@gmail.com" };
            lista[1] = new Profesor() { Id = 2, Nombre = "Loco Lico", Appellido = "Rodriguez", Edad = 23, Telefono = "11111111", Catedra = "Programacion" };
            lista[2] = new Profesor() { Id = 2, Nombre = "Linus", Appellido = "Trovals", Edad = 45, Telefono = "22222", Catedra = "Linux" };

            Console.WriteLine(Persona.ContadorPersonas);
            Console.WriteLine("Resumentes");

            foreach (Persona p in lista)
            {
                System.Console.WriteLine($"Tipo {p.GetType()}");
                Console.WriteLine(p.CounstruirResumen());

                IEnteInstituto ente = p;
                ente.ConstruirLlaveSecreta("Hola");
            }

            System.Console.WriteLine("S T R U C T S");
            CursoStruct c = new CursoStruct(30);
            c.curso = "101-B";

            CursoStruct newC = new CursoStruct();
            newC.curso = "564-A";

            CursoStruct cursoFreak = c;
            cursoFreak.curso = "666-G";

            Console.WriteLine($"Curso C = {c.curso}");
            Console.WriteLine($"Curso Freak = {cursoFreak.curso}");

            System.Console.WriteLine("C L A S E S");
            CursoClass c_class = new CursoClass(40);
            c_class.curso = "101-B";

            CursoClass newC_class = new CursoClass(20);
            newC_class.curso = "564-A";

            CursoClass cursoFreak_class = c_class;
            cursoFreak_class.curso = "666-G";

            Console.WriteLine($"Curso C = {c_class.curso}");
            Console.WriteLine($"Curso Freak = {cursoFreak_class.curso}");

            System.Console.WriteLine("E N U M E R A D O R E S");
            Alumno alumnoEst = new Alumno("Julio", "Rodriguez") { Id = 11, Edad = 15, Telefono = "1111111", Email = "cotorro4@gmail.com", Estado = EstadosAlumno.Expulsado };
            System.Console.WriteLine($"Alumno con Estado {alumnoEst.Estado} ");
            System.Console.WriteLine($"Tipo: {typeof(Alumno)}");
            System.Console.WriteLine($"Get Tipo: {alumnoEst.GetType()}");
            System.Console.WriteLine($"Tipo: {nameof(Alumno)}");
            System.Console.WriteLine($"Tamaño: {sizeof(int)}");

            System.Console.WriteLine($"Tipo: {alumnoEst.GetType()}");
        }
    }
}
