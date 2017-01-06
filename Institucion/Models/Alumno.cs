namespace Institucion.Models
{
    public class Alumno : Persona
    {
        public EstadosAlumno Estado { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string ListaInacistencias()
        {
            return Inasistencias.ToString();
        }

        public Alumno(string nombre, string appellido)
        {
            Nombre = nombre;
            Appellido = appellido;
        }

        public override string CounstruirResumen()
        {
            return $"{NombreCompleto}, {NickName}, {Telefono}";
        }

        public override string NombreCompleto
        {
            get
            {
                return base.NombreCompleto.ToUpper();
            }
        }
    }
}