namespace Institucion.Models
{
    public class CursoClass
    {
        const string NOMBRE_DEFECT_CURSO = "No asignado";
        public string curso { get; set; }
        public readonly short max_capacidad; 
        
        public CursoClass(short max_cap)
        {
            max_capacidad = max_cap;
            curso = NOMBRE_DEFECT_CURSO;
        }
    }
}