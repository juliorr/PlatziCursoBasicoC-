namespace Institucion.Models
{
    public class Profesor : Persona
    {
        public string Catedra { get; set; }
        public override string CounstruirResumen()
        {
            return $"{NombreCompleto}, {Catedra}, {Edad}";
        }
    }
}