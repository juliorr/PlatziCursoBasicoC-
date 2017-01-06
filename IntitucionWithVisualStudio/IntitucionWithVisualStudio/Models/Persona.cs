using System;

namespace IntitucionWithVisualStudio
{
	public abstract class Persona : IEnteInstituto
	{
		public static int ContadorPersonas = 0;

		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Appellido { get; set; }
		public short Edad { get; set; }
		public string Telefono { get; set; }

		public virtual string NombreCompleto
		{
			get
			{
				return $"{Nombre} {Appellido}";
			}
		}
		protected int Inasistencias { get; set; }

		public string CodigoInterno
		{
			get;

			set;
		}

		public Persona()
		{
			ContadorPersonas++;
		}

		public abstract string CounstruirResumen();

		public string ConstruirLlaveSecreta(string nombreEnte)
		{
			var random = new Random();
			return random.Next(1, 666).ToString();
		}
	}
}

